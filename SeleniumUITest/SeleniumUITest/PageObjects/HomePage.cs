using FluentAssertions;
using SeleniumUITest.Core;
using SeleniumUITest.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.PageObjects
{
    public class HomePage : Page
    {
         
        public HomePage(Browser browser) : base(browser) { }

        public HomePage VerifyHomePageIsVisible()
        {

            Wait.UntilSuccess(() =>
            {
                Driver.Title.Should().NotBeNullOrEmpty();
                return true;
            }, DefaultTimeout);

            return this;
        }
    }
}
