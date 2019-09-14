using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumUITest.Core;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.TestData
{
    public static class MainFixtureData
    {
        public static IEnumerable FixtureParms
        {
            get
            {
                yield return new TestFixtureData(new DriverConfig {DriverType= DriverType.Chrome, DriverOptions=new ChromeOptions() }, "http://www.example.com");
                
            }
        }
    }
}
