
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Utilities
{
    public static class Wait
    {
        public static T UntilSuccess<T>(Func<T> statement, int timeoutInSeconds, int pollingInMilliseconds = 500, string message = "")
        {
            DefaultWait<object> defaultWait1 = new DefaultWait<object>(false, new SystemClock())
            {
                Timeout = (TimeSpan.FromSeconds(timeoutInSeconds)),
                PollingInterval = (TimeSpan.FromMilliseconds(pollingInMilliseconds)),
                Message = message
            };
            DefaultWait<object> defaultWait2 = defaultWait1;
            Type[] typeArray = new Type[1];
            int index = 0;
            Type type = typeof(Exception);
            typeArray[index] = type;
            defaultWait2.IgnoreExceptionTypes(typeArray);
            try
            {
                return defaultWait1.Until(f =>
                {
                    try
                    {
                        return statement();
                    }
                    catch (Exception ex)
                    {
                       
                        throw;
                    }
                });
            }
            catch (WebDriverTimeoutException ex)
            {

                throw new TimeoutException(ex.Message, ex.InnerException);
            }
        }
    }
}
