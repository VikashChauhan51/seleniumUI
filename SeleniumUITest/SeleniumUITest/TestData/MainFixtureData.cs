using NUnit.Framework;
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
                yield return new TestFixtureData(DriverType.Chrome, "http://www.example.com");
                yield return new TestFixtureData(DriverType.Firefox, "http://www.example.com");
                yield return new TestFixtureData(DriverType.InternetExplorer, "http://www.example.com");
            }
        }
    }
}
