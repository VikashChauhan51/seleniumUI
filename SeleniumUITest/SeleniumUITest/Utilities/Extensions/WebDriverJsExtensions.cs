using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest
{
    public static class WebDriverJsExtensions
    {
        public static void ScrollToTop(this IWebDriver driver, int timeoutInSeconds = 15)
        {
            WebDriverWait webDriverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            WebDriverWait webDriverWait2 = webDriverWait1;
            Type[] typeArray = new Type[1];
            int index = 0;
            Type type = typeof(Exception);
            typeArray[index] = type;
            webDriverWait2.IgnoreExceptionTypes(typeArray);
            webDriverWait1.Until(drv =>
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);", new object[0]);
                return true;
            });
        }

        public static void ScrollToBottom(this IWebDriver driver, int timeoutInSeconds = 15)
        {
            WebDriverWait webDriverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            WebDriverWait webDriverWait2 = webDriverWait1;
            Type[] typeArray = new Type[1];
            int index = 0;
            Type type = typeof(Exception);
            typeArray[index] = type;
            webDriverWait2.IgnoreExceptionTypes(typeArray);
            webDriverWait1.Until(drv =>
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight || document.documentElement.scrollHeight);", new object[0]);
                return true;
            });
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement element, bool toTop = true, int timeoutInSeconds = 15)
        {
            WebDriverWait webDriverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            WebDriverWait webDriverWait2 = webDriverWait1;
            Type[] typeArray = new Type[1];
            int index1 = 0;
            Type type = typeof(Exception);
            typeArray[index1] = type;
            webDriverWait2.IgnoreExceptionTypes(typeArray);
            webDriverWait1.Until(drv =>
            {
                IJavaScriptExecutor ijavaScriptExecutor = (IJavaScriptExecutor)driver;
                string str = "arguments[0].scrollIntoView(arguments[1]);";
                object[] objArray = new object[2];
                int index2 = 0;
                IWebElement iwebElement = element;
                objArray[index2] = (object)iwebElement;
                int index3 = 1;
                var local = toTop ? 1 : 0;
                objArray[index3] = (object)local;
                ijavaScriptExecutor.ExecuteScript(str, objArray);
                return true;
            });
        }

        public static void ScrollToElement(this IWebDriver driver, By by, bool toTop = true, int timeoutInSeconds = 15)
        {
            WebDriverWait webDriverWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            WebDriverWait webDriverWait2 = webDriverWait1;
            Type[] typeArray = new Type[1];
            int index1 = 0;
            Type type = typeof(Exception);
            typeArray[index1] = type;
            webDriverWait2.IgnoreExceptionTypes(typeArray);
            webDriverWait1.Until(drv =>
            {
                IJavaScriptExecutor ijavaScriptExecutor = (IJavaScriptExecutor)driver;
                string str = "arguments[0].scrollIntoView(arguments[1]);";
                object[] objArray = new object[2];
                int index2 = 0;
                IWebElement element = driver.FindElement(by);
                objArray[index2] = element;
                int index3 = 1;
                var local = toTop ? 1 : 0;
                objArray[index3] = local;
                ijavaScriptExecutor.ExecuteScript(str, objArray);
                return true;
            });
        }
    }
}
