using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumUITest.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace SeleniumUITest.Core
{
    public class Browser
    {
        private readonly IWebDriver _driver;
        public ICapabilities Capabilities => ((RemoteWebDriver)_driver).Capabilities;
        public IWebDriver Driver => _driver;
        public Browser(IWebDriver driver)
        {
            this._driver = driver;

        }

        public void Quit()
        {
            this._driver?.Quit();
            this._driver?.Dispose();
        }
        public void GoTo(string url, int timeoutInSeconds = 180)
        {
            Wait.UntilSuccess(() =>
            {
                this.Driver.Navigate().GoToUrl(url);
                return true;
            }, timeoutInSeconds, 5000, "");
        }

        public void GoBack()
        {
            this.Driver.Navigate().Back();
        }

        public void GoForward()
        {
            this.Driver.Navigate().Forward();
        }

        public void Refresh()
        {
            this.Driver.Navigate().Refresh();
        }

        public void ScrollToTop(int timeoutInSeconds = 15)
        {

            WebDriverJsExtensions.ScrollToTop(this.Driver, timeoutInSeconds);
        }

        public void ScrollToBottom(int timeoutInSeconds = 15)
        {
            WebDriverJsExtensions.ScrollToBottom(this.Driver, timeoutInSeconds);
        }
        public ReadOnlyCollection<string> GetAllWindows()
        {
            return this.Driver.WindowHandles;
        }

        public string GetCurrentWindow()
        {
            return this.Driver.CurrentWindowHandle;
        }
        public void SwitchToWindow(string window, int timeoutInSeconds = 15)
        {

            Wait.UntilSuccess(() => this.Driver.SwitchTo().Window(window), timeoutInSeconds, 500, "");
        }

        public int GetWindowCount()
        {
            return this.Driver.WindowHandles.Count;
        }

        public void VerifyWindowCount(int expectedCount, int timeoutInSeconds = 15)
        {
            Wait.UntilSuccess(() => this.Driver.WindowHandles.Count == expectedCount, timeoutInSeconds, 500, "");
        }

        public void VerifyTitleIs(string title, int timeoutInSeconds = 15)
        {
            Wait.UntilSuccess(() => this.Driver.Title.Equals(title), timeoutInSeconds, 500, "");
        }

        public void VerifyUrlIs(string url, int timeoutInSeconds = 15)
        {
            Wait.UntilSuccess(() => this.Driver.Url.Equals(url), timeoutInSeconds, 500, "");
        }

        public void VerifyUrlContains(string url, int timeoutInSeconds = 15)
        {

            Wait.UntilSuccess(() => this.Driver.Url.Contains(url), timeoutInSeconds, 500, "");
        }
        public void ExecuteJavaScript(string script, int timeoutInSeconds = 15)
        {

            Wait.UntilSuccess(() =>
            {
                ((IJavaScriptExecutor)this.Driver).ExecuteScript(script, new object[0]);
                return true;
            }, timeoutInSeconds, 500, "");
        }

        public object ExecuteJavaScriptUntilReturns(string script, int timeoutInSeconds = 15)
        {

            return Wait.UntilSuccess(() => ((IJavaScriptExecutor)this.Driver).ExecuteScript(script, new object[0]), timeoutInSeconds, 500, "");
        }

        public void MaximizeWindow()
        {

            this.Driver.Manage().Window.Maximize();
        }

        public int GetWindowWidth()
        {
            return this.Driver.Manage().Window.Size.Width;
        }

        public int GetWindowHeight()
        {
            return this.Driver.Manage().Window.Size.Height;
        }

        public void ResizeWindow(int width, int height)
        {

            this.Driver.Manage().Window.Size = (new Size(width, height));
        }

        public void SetImplicitWait(int milliseconds)
        {

            this.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromMilliseconds((double)milliseconds));
        }
        public void SaveScreenshot(string path)
        {
            ((ITakesScreenshot)this.Driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}
