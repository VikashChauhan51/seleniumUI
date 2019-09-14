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
        private static readonly string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


        public static Browser OpenBrowser(DriverConfig config)
        {
            switch (config.DriverType)
            {
                case DriverType.Chrome:
                    return new Browser(OpenChrome((ChromeOptions)config.DriverOptions));
                case DriverType.Edge:
                    return new Browser(OpenEdge((EdgeOptions)config.DriverOptions));
                case DriverType.Firefox:
                    return new Browser(OpenFirefox((FirefoxOptions)config.DriverOptions));
                case DriverType.InternetExplorer:
                    return new Browser(OpenIE((InternetExplorerOptions)config.DriverOptions));
                case DriverType.Opera:
                    return new Browser(OpenOpera((OperaOptions)config.DriverOptions));
                case DriverType.Safari:
                    return new Browser(OpenSafari((SafariOptions)config.DriverOptions));
                case DriverType.Remote:
                    return new Browser(OpenChrome((ChromeOptions)config.DriverOptions));
                case DriverType.BrowserStack:
                    return new Browser(OpenChrome((ChromeOptions)config.DriverOptions));
                case DriverType.Unknown:
                    return new Browser(OpenChrome((ChromeOptions)config.DriverOptions));
                default:
                    return null;
            }


        }

        private static IWebDriver OpenChrome(ChromeOptions options)
        {
            return new ChromeDriver(driverPath);
        }

        private static IWebDriver OpenEdge(EdgeOptions options)
        {
            return new EdgeDriver(driverPath);
        }

        private static IWebDriver OpenFirefox(FirefoxOptions options)
        {
            return new FirefoxDriver(driverPath);
        }

        private static IWebDriver OpenIE(InternetExplorerOptions options)
        {
            return new InternetExplorerDriver(driverPath);
        }

        private static IWebDriver OpenOpera(OperaOptions options)
        {
            return new OperaDriver(driverPath);
        }

        private static IWebDriver OpenSafari(SafariOptions options)
        {
            return new SafariDriver(driverPath);
        }

        //private IWebDriver OpenRemote(ChromeOptions options)
        //{
            //DesiredCapabilities
        //    return new RemoteWebDriver(new Uri(this.RemoteUrl), (ICapabilities)this.DefaultConfigObject.RemoteCapabilities);
        //}
    }
}
