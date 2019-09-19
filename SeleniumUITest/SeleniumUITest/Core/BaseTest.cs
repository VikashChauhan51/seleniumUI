using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUITest.i18n;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SeleniumUITest.Core
{

    public abstract class BaseTest
    {

        private readonly DriverFactory _driverFactory;
        private static EnvironmentConfig _envConfig;
        protected Browser WebBrowser { get; private set; }
        protected readonly string language;
        static BaseTest()
        {
            ReadConfig();
        }
        protected BaseTest(string language)
        {
            this.language = language;
            Resource.Culture = new CultureInfo(language);
            this._driverFactory = new DriverFactory(_envConfig);
            this._driverFactory.DriverStarting += OnDriverStarting;

        }
        public static string ProjectDirectory
        {
            get
            {
                var projectName = Assembly.GetExecutingAssembly().GetName().Name;
                var info = new DirectoryInfo(CurrentDirectory);
                while (info != null)
                {
                    if (info.Name.Equals(projectName))
                    {
                        return info.FullName;
                    }
                    info = info.Parent;
                }
                return null;

            }
        }
        public static string RootDirectory
        {
            get
            {
                return new DirectoryInfo(CurrentDirectory).Root.FullName;

            }
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
            WebBrowser.SetImplicitWait(_envConfig.DefaultWaitTime);
            WebBrowser.GoTo(_envConfig.Url);
        }

        protected void Completed()
        {
            WebBrowser?.Quit();
            WebBrowser = null;
        }

        private static void ReadConfig()
        {

            string defaultConfigFile = Path.Combine(ProjectDirectory, "appconfig.json");
            string configFile = TestContext.Parameters.Get<string>("ConfigFile", defaultConfigFile).Replace('/', Path.DirectorySeparatorChar);

            string content = File.ReadAllText(configFile);
            _envConfig = JsonConvert.DeserializeObject<EnvironmentConfig>(content);

        }
    }
}
