using OpenQA.Selenium;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
   public class DriverConfig
    {
        public DriverType DriverType { get; set; }
        public DriverOptions DriverOptions { get; set; }
        public string RemoteUrl { get; set; }
    }
}
