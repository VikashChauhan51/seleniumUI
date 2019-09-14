using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumUITest
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindVisibleElement(this IWebDriver driver, By by)
        {
            var iwebelement = Enumerable.FirstOrDefault(driver.FindElements(by), x => x.Displayed);
            if (iwebelement == null)
                throw new NoSuchElementException("no visible element found");
            return iwebelement;
        }
        public static IWebElement FindClickableElement(this IWebDriver driver, By by)
        {
            IWebElement iwebElement = Enumerable.FirstOrDefault(driver.FindElements(by), x =>
            {
                return x.Displayed && x.Enabled;
            });
            if (iwebElement == null)
                throw new NoSuchElementException("No clickable (visible and enabled) element found!");
            return iwebElement;
        }
    }
}
