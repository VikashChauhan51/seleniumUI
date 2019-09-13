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


        public static IWebDriver OpenBrowser(DriverType DriverType)
        {
            switch (DriverType)
            {
                case DriverType.Chrome:
                    return OpenChrome();
                case DriverType.Edge:
                    return OpenEdge();
                case DriverType.Firefox:
                    return OpenFirefox();
                case DriverType.InternetExplorer:
                    return OpenIE();
                case DriverType.Opera:
                    return OpenOpera();
                case DriverType.Safari:
                    return OpenSafari();
                case DriverType.Remote:
                    return OpenChrome();
                case DriverType.BrowserStack:
                    return OpenChrome();
                case DriverType.Unknown:
                    return OpenChrome();
                default:
                    return null;
            }


        }

        private static ChromeDriver OpenChrome()
        {
            return new ChromeDriver(driverPath);
        }

        private static EdgeDriver OpenEdge()
        {
            return new EdgeDriver(driverPath);
        }

        private static FirefoxDriver OpenFirefox()
        {
            return new FirefoxDriver(driverPath);
        }

        private static InternetExplorerDriver OpenIE()
        {
            return new InternetExplorerDriver(driverPath);
        }

        private static OperaDriver OpenOpera()
        {
            return new OperaDriver(driverPath);
        }

        private static SafariDriver OpenSafari()
        {
            return new SafariDriver(driverPath);
        }

        //private IWebDriver OpenRemote()
        //{
        //    return new RemoteWebDriver(new Uri(this.RemoteUrl), (ICapabilities)this.DefaultConfigObject.RemoteCapabilities);
        //}
    }
}
