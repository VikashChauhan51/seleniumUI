using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumUITest.Core;
using SeleniumUITest.i18n;
using SeleniumUITest.PageObjects;
using SeleniumUITest.TestData;
using SeleniumUITest.Utilities.Enums;

namespace Tests
{
    [TestFixtureSource(typeof(MainFixtureData), "FixtureParms")]
    public class HomeTest : BaseTest
    {
        public HomeTest(string language):base(language)
        {

        }   

        [Test]
        public void Test1()
        {
            Console.WriteLine(Resource.ApplicationName);
            new HomePage(this.WebBrowser)
                .VerifyHomePageIsVisible();
            Assert.Pass();
        }
         
    }
}