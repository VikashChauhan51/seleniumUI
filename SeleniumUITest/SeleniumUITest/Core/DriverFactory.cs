using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumUITest.Core
{
    public class DriverFactory
    {
        private readonly DriverType _driverType;
        private readonly DriverOptions _options;
        private static readonly string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly Dictionary<DriverType, Type> serviceTypes = new Dictionary<DriverType, Type>();
        private static readonly Dictionary<DriverType, Type> optionsTypes = new Dictionary<DriverType, Type>();
        private static readonly Dictionary<DriverType, Type> driverTypes = new Dictionary<DriverType, Type>();
        public event EventHandler<DriverStartingEventArgs> DriverStarting;
        static DriverFactory()
        {
            PopulateOptionsTypes();
            PopulateServiceTypes();
            PopulateDriverTypes();
        }
        public DriverFactory(DriverType driverType, DriverOptions options)
        {
            this._driverType = driverType;
            this._options = options;
        }
        private static void PopulateOptionsTypes()
        {
            optionsTypes[DriverType.Chrome] = typeof(ChromeOptions);
            optionsTypes[DriverType.Edge] = typeof(EdgeOptions);
            optionsTypes[DriverType.Firefox] = typeof(FirefoxOptions);
            optionsTypes[DriverType.InternetExplorer] = typeof(InternetExplorerOptions);
            optionsTypes[DriverType.Opera] = typeof(OperaOptions);
            optionsTypes[DriverType.Safari] = typeof(SafariOptions);
        }
        private static void PopulateServiceTypes()
        {
            serviceTypes[DriverType.Chrome] = typeof(ChromeDriverService);
            serviceTypes[DriverType.Edge] = typeof(EdgeDriverService);
            serviceTypes[DriverType.Firefox] = typeof(FirefoxDriverService);
            serviceTypes[DriverType.InternetExplorer] = typeof(InternetExplorerDriverService);
            serviceTypes[DriverType.Opera] = typeof(OperaDriverService);
            serviceTypes[DriverType.Safari] = typeof(SafariDriverService);
        }
        private static void PopulateDriverTypes()
        {
            driverTypes[DriverType.Chrome] = typeof(ChromeDriver);
            driverTypes[DriverType.Edge] = typeof(EdgeDriver);
            driverTypes[DriverType.Firefox] = typeof(FirefoxDriver);
            driverTypes[DriverType.InternetExplorer] = typeof(InternetExplorerDriver);
            driverTypes[DriverType.Opera] = typeof(OperaDriver);
            driverTypes[DriverType.Safari] = typeof(SafariDriver);
        }

        public Browser OpenBrowser()
        {
            Type browserType = typeof(Browser);
            IWebDriver driver = CreateDriverWithOptions(_driverType, _options);
            List<Type> constructorArgTypeList = new List<Type>();
            constructorArgTypeList.Add(typeof(IWebDriver));
            ConstructorInfo ctorInfo = browserType.GetConstructor(constructorArgTypeList.ToArray());
            if (ctorInfo != null)
            {
                return (Browser)ctorInfo.Invoke(new object[] { driver });
            }

            return (Browser)Activator.CreateInstance(browserType);
        }
        protected void OnDriverLaunching(DriverService service, DriverOptions options)
        {
            if (this.DriverStarting != null)
            {
                DriverStartingEventArgs args = new DriverStartingEventArgs(service, options);
                this.DriverStarting(this, args);
            }
        }
        private IWebDriver CreateDriverWithOptions(DriverType browser, DriverOptions driverOptions)
        {
            DriverService service = null;
            DriverOptions options = null;
            Type driverType = driverTypes[browser];
            List<Type> constructorArgTypeList = new List<Type>();
            IWebDriver driver = null;
            switch (browser)
            {
                case DriverType.Chrome:

                    options = GetDriverOptions<ChromeOptions>(driverType, driverOptions);
                    service = CreateService<ChromeDriverService>(driverType);
                    break;
                case DriverType.Edge:
                    options = GetDriverOptions<EdgeOptions>(driverType, driverOptions);
                    service = CreateService<EdgeDriverService>(driverType);
                    break;
                case DriverType.Firefox:
                    options = GetDriverOptions<FirefoxOptions>(driverType, driverOptions);
                    service = CreateService<FirefoxDriverService>(driverType);
                    break;
                case DriverType.InternetExplorer:
                    options = GetDriverOptions<InternetExplorerOptions>(driverType, driverOptions);
                    service = CreateService<InternetExplorerDriverService>(driverType);
                    break;
                case DriverType.Opera:
                    options = GetDriverOptions<OperaOptions>(driverType, driverOptions);
                    service = CreateService<OperaDriverService>(driverType);
                    break;
                case DriverType.Safari:
                    options = GetDriverOptions<SafariOptions>(driverType, driverOptions);
                    service = CreateService<SafariDriverService>(driverType);
                    break;
                case DriverType.Remote:
                    break;
            }

            this.OnDriverLaunching(service, options);
            constructorArgTypeList.Add(serviceTypes[browser]);
            constructorArgTypeList.Add(optionsTypes[browser]);
            ConstructorInfo ctorInfo = driverType.GetConstructor(constructorArgTypeList.ToArray());
            if (ctorInfo != null)
            {
                return (IWebDriver)ctorInfo.Invoke(new object[] { service, options });
            }

            driver = (IWebDriver)Activator.CreateInstance(driverType);
            return driver;
        }

        private static T GetDriverOptions<T>(Type driverType, DriverOptions overriddenOptions) where T : DriverOptions, new()
        {
            T options = new T();
            Type optionsType = typeof(T);

            PropertyInfo defaultOptionsProperty = driverType.GetProperty("DefaultOptions", BindingFlags.Public | BindingFlags.Static);
            if (defaultOptionsProperty != null && defaultOptionsProperty.PropertyType == optionsType)
            {
                options = (T)defaultOptionsProperty.GetValue(null, null);
            }

            if (overriddenOptions != null)
            {
                options.PageLoadStrategy = overriddenOptions.PageLoadStrategy;
                options.UnhandledPromptBehavior = overriddenOptions.UnhandledPromptBehavior;
                options.Proxy = overriddenOptions.Proxy;
            }

            return options;
        }

        private static T MergeOptions<T>(object baseOptions, DriverOptions overriddenOptions) where T : DriverOptions, new()
        {
            // If the driver type has a static DefaultOptions property,
            // get the value of that property, which should be a valid
            // options of the generic type (T). Otherwise, create a new
            // instance of the browser-specific options class.
            T mergedOptions = new T();
            if (baseOptions != null && baseOptions is T)
            {
                mergedOptions = (T)baseOptions;
            }

            if (overriddenOptions != null)
            {
                mergedOptions.PageLoadStrategy = overriddenOptions.PageLoadStrategy;
                mergedOptions.UnhandledPromptBehavior = overriddenOptions.UnhandledPromptBehavior;
                mergedOptions.Proxy = overriddenOptions.Proxy;
            }

            return mergedOptions;
        }

        private static T CreateService<T>(Type driverType) where T : DriverService
        {
            T service = default(T);
            Type serviceType = typeof(T);

            // If the driver type has a static DefaultService property,
            // get the value of that property, which should be a valid
            // service of the generic type (T). Otherwise, invoke the
            // static CreateDefaultService method on the driver service's
            // type, which returns an instance of the type.
            PropertyInfo defaultServiceProperty = driverType.GetProperty("DefaultService", BindingFlags.Public | BindingFlags.Static);
            if (defaultServiceProperty != null && defaultServiceProperty.PropertyType == serviceType)
            {
                PropertyInfo servicePathProperty = driverType.GetProperty("ServicePath", BindingFlags.Public | BindingFlags.Static);
                if (servicePathProperty != null)
                {
                    servicePathProperty.SetValue(null, driverPath);
                }

                service = (T)defaultServiceProperty.GetValue(null, null);
            }
            else
            {
                MethodInfo createDefaultServiceMethod = serviceType.GetMethod("CreateDefaultService", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string) }, null);
                if (createDefaultServiceMethod != null && createDefaultServiceMethod.ReturnType == serviceType)
                {
                    service = (T)createDefaultServiceMethod.Invoke(null, new object[] { driverPath });
                }
            }

            return service;
        }

        private static object GetDefaultOptions(Type driverType)
        {
            PropertyInfo info = driverType.GetProperty("DefaultOptions", BindingFlags.Public | BindingFlags.Static);
            if (info != null)
            {
                object propertyValue = info.GetValue(null, null);
                return propertyValue;
            }

            return null;
        }
    }
}
