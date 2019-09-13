using OpenQA.Selenium;
using SeleniumUITest.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    public abstract class Page
    {
        protected const int DefaultTimeout = 15;

        protected readonly Browser WebBrowser;

        protected readonly IWebDriver Driver;

        public Page(Browser browser)
        {
            this.WebBrowser = browser;
            this.Driver = browser.Driver;


        }
    }
}
