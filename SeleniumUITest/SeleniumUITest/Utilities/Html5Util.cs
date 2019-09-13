using OpenQA.Selenium;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumUITest.Utilities
{
    public static class Html5Util
    {
        public static BrowserType StringToBrowserType(string browserStr)
        {
            string s = browserStr.ToLower();
            var stringHash = s.GetHashCode();
            if (stringHash <= 1250711001U)
            {
                if (stringHash <= 270057011U)
                {
                    if ((int)stringHash != 87446305)
                    {
                        if ((int)stringHash != 180149969)
                        {
                            if ((int)stringHash == 270057011 && s == "chrome")
                                return BrowserType.Chrome;
                        }
                        else if (s == "safari")
                            return BrowserType.Safari;
                    }
                    else if (s == "htmlunitwithjavascript")
                        return BrowserType.HtmlUnitWithJavaScript;
                }
                else
                {
                    if (stringHash <= 943221875U)
                    {
                        if ((int)stringHash != 648365726)
                        {
                            if ((int)stringHash != 943221875 || !(s == "ie"))
                                goto label_39;
                        }
                        else
                        {
                            if (s == "htmlunit")
                                return BrowserType.HtmlUnit;
                            goto label_39;
                        }
                    }
                    else if ((int)stringHash != 1076972979)
                    {
                        if ((int)stringHash == 1250711001 && s == "ipad")
                            return BrowserType.IPad;
                        goto label_39;
                    }
                    else if (!(s == "internetexplorer"))
                        goto label_39;
                    return BrowserType.InternetExplorer;
                }
            }
            else
            {
                if (stringHash <= 1797453421U)
                {
                    if ((int)stringHash != 1459017788)
                    {
                        if ((int)stringHash != 1701601664)
                        {
                            if ((int)stringHash != 1797453421 || !(s == "ff"))
                                goto label_39;
                        }
                        else
                        {
                            if (s == "iphone")
                                return BrowserType.IPhone;
                            goto label_39;
                        }
                    }
                    else
                    {
                        if (s == "edge")
                            return BrowserType.Edge;
                        goto label_39;
                    }
                }
                else if (stringHash <= 2608177081U)
                {
                    if ((int)stringHash != -1910159852)
                    {
                        if ((int)stringHash == -1686790215 && s == "unknown")
                            return BrowserType.Unknown;
                        goto label_39;
                    }
                    else
                    {
                        if (s == "opera")
                            return BrowserType.Opera;
                        goto label_39;
                    }
                }
                else if ((int)stringHash != -187379654)
                {
                    if ((int)stringHash == -98890964 && s == "android")
                        return BrowserType.Android;
                    goto label_39;
                }
                else if (!(s == "firefox"))
                    goto label_39;
                return BrowserType.Firefox;
            }
        label_39:
            throw new NotImplementedException(string.Format("The browserType: {0} is not supported yet!", (object)browserStr));
        }

        public static DriverType StringToDriverType(string driverStr)
        {
            string s = driverStr.ToLower();
            var stringHash = s.GetHashCode();
            if (stringHash <= 1459017788U)
            {
                if (stringHash <= 270057011U)
                {
                    if ((int)stringHash != 180149969)
                    {
                        if ((int)stringHash == 270057011 && s == "chrome")
                            return DriverType.Chrome;
                    }
                    else if (s == "safari")
                        return DriverType.Safari;
                }
                else
                {
                    if ((int)stringHash != 943221875)
                    {
                        if ((int)stringHash != 1076972979)
                        {
                            if ((int)stringHash == 1459017788 && s == "edge")
                                return DriverType.Edge;
                            goto label_30;
                        }
                        else if (!(s == "internetexplorer"))
                            goto label_30;
                    }
                    else if (!(s == "ie"))
                        goto label_30;
                    return DriverType.InternetExplorer;
                }
            }
            else
            {
                if (stringHash <= 2608177081U)
                {
                    if ((int)stringHash != 1797453421)
                    {
                        if ((int)stringHash != -1910159852)
                        {
                            if ((int)stringHash == -1686790215 && s == "unknown")
                                return DriverType.Unknown;
                            goto label_30;
                        }
                        else
                        {
                            if (s == "opera")
                                return DriverType.Opera;
                            goto label_30;
                        }
                    }
                    else if (!(s == "ff"))
                        goto label_30;
                }
                else if ((int)stringHash != -1254955327)
                {
                    if ((int)stringHash != -947029677)
                    {
                        if ((int)stringHash != -187379654 || !(s == "firefox"))
                            goto label_30;
                    }
                    else
                    {
                        if (s == "remote")
                            return DriverType.Remote;
                        goto label_30;
                    }
                }
                else
                {
                    if (s == "browserstack")
                        return DriverType.BrowserStack;
                    goto label_30;
                }
                return DriverType.Firefox;
            }
        label_30:
            throw new NotImplementedException(string.Format("The driverType: {0} is not supported yet!", (object)driverStr));
        }

        public static DriverType GuessDriverType(object webdriver)
        {
            string s = webdriver.GetType().ToString();

            var stringHash = s.GetHashCode();
            if (stringHash <= 1320769905U)
            {
                if ((int)stringHash != 237783371)
                {
                    if ((int)stringHash != 385655501)
                    {
                        if ((int)stringHash == 1320769905 && s == "OpenQA.Selenium.Safari.SafariDriver")
                            return DriverType.Safari;
                    }
                    else if (s == "OpenQA.Selenium.Remote.RemoteWebDriver")
                        return DriverType.Remote;
                }
                else if (s == "OpenQA.Selenium.Edge.EdgeDriver")
                    return DriverType.Edge;
            }
            else if (stringHash <= 2250483817U)
            {
                if ((int)stringHash != 1925240273)
                {
                    if ((int)stringHash == -2044483479 && s == "OpenQA.Selenium.Opera.OperaDriver")
                        return DriverType.Opera;
                }
                else if (s == "OpenQA.Selenium.Chrome.ChromeDriver")
                    return DriverType.Chrome;
            }
            else if ((int)stringHash != -1646914067)
            {
                if ((int)stringHash == -747853211 && s == "OpenQA.Selenium.Firefox.FirefoxDriver")
                    return DriverType.Firefox;
            }
            else if (s == "OpenQA.Selenium.IE.InternetExplorerDriver")
                return DriverType.InternetExplorer;
            return DriverType.Unknown;
        }

        private static string CombineMessages(params string[] messages)
        {
            return string.Join(" - ", Enumerable.Where<string>((IEnumerable<string>)messages, (Func<string, bool>)(s => !string.IsNullOrEmpty(s))));
        }


    }
}
