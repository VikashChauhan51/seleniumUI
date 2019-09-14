using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumUITest
{
    public static class WebElementExtensions
    {
        internal static TResult RetryUntilNotStale<T, TResult>(Func<T, TResult> statement, T element, int retryIfStale = 5)
        {
            try
            {
                return statement(element);
            }
            catch (Exception ex)
            {
                if ( retryIfStale > 1)
                {
                    Thread.Sleep(200);
                    return RetryUntilNotStale(statement, element, retryIfStale - 1);
                }
                throw;
            }
             
        }
    }
}
