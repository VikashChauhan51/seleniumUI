using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumUITest.Core
{
    
    public abstract class BaseTest
    {

        private readonly DriverFactory _driverFactory;
        private readonly string _url;
        protected Browser WebBrowser { get; private set; }
        private const int _defaultWaitTime = 30000;
        public BaseTest(DriverType driverType)
        {
            this._driverFactory = new DriverFactory(driverType);
            this._driverFactory.DriverStarting += OnDriverStarting;
            this._url = "http://www.example.com";
        }

        public static string CurrentDirectory
        {
            get
            {
                string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string testDirectory = TestContext.CurrentContext.TestDirectory;
                if (assemblyLocation != testDirectory)
                {
                    return assemblyLocation;
                }
                return testDirectory;
            }
        }
        private void OnDriverStarting(object sender, DriverStartingEventArgs e)
        {
            Console.WriteLine(e.Service.HostName);
        }

        [SetUp]
        public void BeforeTest()
        {
            Init();
        }
        [TearDown]
        public void AfterTest()
        {
            Completed();
        }
        protected void Init()
        {
            WebBrowser = _driverFactory.OpenBrowser();
            WebBrowser.MaximizeWindow();
            WebBrowser.SetImplicitWait(_defaultWaitTime);
            WebBrowser.GoTo(_url);
        }

        protected void Completed()
        {
            WebBrowser?.Quit();
            WebBrowser = null;
        }

        private static void ReadConfig()
        {
            string defaultConfigFile = Path.Combine(CurrentDirectory, "appconfig.json");
            string configFile = TestContext.Parameters.Get<string>("ConfigFile", defaultConfigFile).Replace('/', Path.DirectorySeparatorChar);

            string content = File.ReadAllText(configFile);
            TestConfig env = JsonConvert.DeserializeObject<TestConfig>(content);
            bool captureWebServerOutput = TestContext.Parameters.Get<bool>("CaptureWebServerOutput", env.CaptureWebServerOutput);
        }
    }
}
