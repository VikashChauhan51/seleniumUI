
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
            DefaultWait<object> defaultWait1 = new DefaultWait<object>((object)false, new SystemClock());
            defaultWait1.Timeout = (TimeSpan.FromSeconds((double)timeoutInSeconds));
            defaultWait1.PollingInterval = (TimeSpan.FromMilliseconds((double)pollingInMilliseconds));
            defaultWait1.Message = message;
            DefaultWait<object> defaultWait2 = defaultWait1;
            Type[] typeArray = new Type[1];
            int index = 0;
            Type type = typeof(Exception);
            typeArray[index] = type;
            defaultWait2.IgnoreExceptionTypes(typeArray);
            try
            {
                return defaultWait1.Until<T>((Func<object, T>)(f =>
                {
                    try
                    {
                        return statement();
                    }
                    catch (Exception ex)
                    {
                        //Log.Test.DebugFormat("This attempt failed for: {0}", (object)ex.Message);
                        throw;
                    }
                }));
            }
            catch (WebDriverTimeoutException ex)
            {
                //Log.Test.DebugFormat("The final attempt failed for: {0}, InnerException: {1}", (object)((Exception)ex).Message, (object)((Exception)ex).InnerException);
                throw new TimeoutException(((Exception)ex).Message, ((Exception)ex).InnerException);
            }
        }
    }
}
