using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumUITest.Core;
using SeleniumUITest.PageObjects;
using SeleniumUITest.TestData;
using SeleniumUITest.Utilities.Enums;

namespace Tests
{
    [TestFixture]
    public class HomeTest : BaseTest
    {
        public HomeTest()
        {

        }   

        [Test]
        public void Test1()
        {
            new HomePage(this.WebBrowser)
                .VerifyHomePageIsVisible();
            Assert.Pass();
        }
    }
}