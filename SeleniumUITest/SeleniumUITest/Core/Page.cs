using OpenQA.Selenium;
using SeleniumUITest.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    public abstract class Page
    {
        private readonly PageFactory _pageFactory;
        protected const int DefaultTimeout = 30;
        protected readonly Browser WebBrowser;
        protected readonly IWebDriver Driver;

        public Page(Browser browser)
        {
            this.WebBrowser = browser;
            this.Driver = browser.Driver;
            this._pageFactory = new PageFactory(browser);


        }
        protected T GetPage<T>() where T : Page => _pageFactory.GetPage<T>();
        protected T GetNewPage<T>() where T : Page => _pageFactory.GetNewPage<T>();
    }
}
