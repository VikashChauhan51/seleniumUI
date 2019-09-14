using OpenQA.Selenium;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    public abstract class BaseTest
    {

        private readonly DriverType _driverType;
        private readonly DriverOptions _options;
        private readonly string _url;
        protected Browser WebBrowser { get; private set; }
        public BaseTest(DriverType driverType, DriverOptions options, string url)
        {
            this._driverType = driverType;
            this._options = options;
            this._url = url;
        }
        protected void Init()
        {
            WebBrowser = new DriverFactory(_driverType, _options).OpenBrowser();
            WebBrowser.GoTo(_url);
        }

        protected void Completed()
        {
            WebBrowser?.Quit();
        }
    }
}
