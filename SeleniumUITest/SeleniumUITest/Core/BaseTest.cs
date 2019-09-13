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
        private readonly string _url;
        protected Browser WebBrowser { get; private set; }
        public BaseTest(DriverType driverType, string url)
        {
            this._driverType = driverType;
            this._url = url;
        }
        protected void Init()
        {
            WebBrowser = new Browser(DriverFactory.OpenBrowser(_driverType));
            WebBrowser.GoTo(_url);
        }

        protected void Completed()
        {
            WebBrowser?.Quit();
        }
    }
}
