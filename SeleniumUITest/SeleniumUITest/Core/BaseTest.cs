using OpenQA.Selenium;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    public abstract class BaseTest
    {

        private readonly DriverConfig _config;
        private readonly string _url;
        protected Browser WebBrowser { get; private set; }
        public BaseTest(DriverConfig config, string url)
        {
            this._config = config;
            this._url = url;
        }
        protected void Init()
        {
            WebBrowser = DriverFactory.OpenBrowser(_config);
            WebBrowser.GoTo(_url);
        }

        protected void Completed()
        {
            WebBrowser?.Quit();
        }
    }
}
