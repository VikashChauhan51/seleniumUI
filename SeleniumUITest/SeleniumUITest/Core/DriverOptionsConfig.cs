using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
   public class DriverOptionsConfig
    {
        public static List<string> ChromeArgumentsList { get; internal set; }

        public static List<string> FirefoxArgumentsList { get; internal set; }

        public static List<string> OperaArgumentsList { get; internal set; }

        public static List<string> ChromeExtensionsList { get; internal set; }

        public static List<string> FirefoxExtensionsList { get; internal set; }

        public static List<string> OperaExtensionsList { get; internal set; }

        public static Dictionary<string, object> ChromeOptionsDict { get; internal set; }

        public static Dictionary<string, object> ChromeUserProfilePreferencesDict { get; internal set; }

        public static Dictionary<string, object> EdgeOptionsDict { get; internal set; }

        public static Dictionary<string, object> FirefoxOptionsDict { get; internal set; }

        public static Dictionary<string, object> FirefoxProfilePreferencesDict { get; internal set; }

        public static Dictionary<string, object> InternetExplorerOptionsDict { get; internal set; }

        public static Dictionary<string, object> OperaOptionsDict { get; internal set; }

        public static Dictionary<string, object> SafariOptionsDict { get; internal set; }

        public static Dictionary<string, object> RemoteCapabilitiesDict { get; internal set; }

        public ChromeOptions ChromeOptions { get; private set; }

        public EdgeOptions EdgeOptions { get; private set; }

        public FirefoxOptions FirefoxOptions { get; private set; }

        public InternetExplorerOptions InternetExplorerOptions { get; private set; }

        public OperaOptions OperaOptions { get; private set; }

        public SafariOptions SafariOptions { get; private set; }

        public DesiredCapabilities RemoteCapabilities { get; private set; }
        private ChromeOptions CreateChromeConfig()
        {
          
            ChromeOptions chromeOptions = new ChromeOptions();
            if (ChromeExtensionsList.Count > 0)
            {
                chromeOptions.AddExtensions(ChromeExtensionsList);

            }
            if (ChromeArgumentsList.Count > 0)
            {
                chromeOptions.AddArguments(ChromeArgumentsList);

            }
            foreach (KeyValuePair<string, object> keyValuePair in ChromeOptionsDict)
            {
                chromeOptions.AddAdditionalCapability(keyValuePair.Key, keyValuePair.Value);
            }
            foreach (KeyValuePair<string, object> keyValuePair in ChromeUserProfilePreferencesDict)
            {
                chromeOptions.AddUserProfilePreference(keyValuePair.Key, keyValuePair.Value);

            }
            return chromeOptions;
        }

        private EdgeOptions CreateEdgeConfig()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            foreach (KeyValuePair<string, object> keyValuePair in EdgeOptionsDict)
            {
                edgeOptions.AddAdditionalCapability(keyValuePair.Key, keyValuePair.Value);
            }
            return edgeOptions;
        }

        private FirefoxOptions CreateFirefoxConfig()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            foreach (string str in FirefoxExtensionsList)
            {
                firefoxProfile.AddExtension(str);
            }
            if (FirefoxArgumentsList.Count > 0)
            {
                firefoxOptions.AddArguments(FirefoxArgumentsList);

            }
            foreach (KeyValuePair<string, object> keyValuePair in FirefoxProfilePreferencesDict)
            {
                if (keyValuePair.Value.GetType() == typeof(bool))
                    firefoxProfile.SetPreference(keyValuePair.Key, (bool)keyValuePair.Value);
                else if (keyValuePair.Value.GetType() == typeof(int))
                {
                    firefoxProfile.SetPreference(keyValuePair.Key, (int)keyValuePair.Value);
                }
                else
                {
                    if (!(keyValuePair.Value.GetType() == typeof(string)))
                        throw new NotImplementedException(string.Format("There is no support for setting Firefox preferences of type: {0}", (object)keyValuePair.Value.GetType()));
                    firefoxProfile.SetPreference(keyValuePair.Key, (string)keyValuePair.Value);
                }
            }
            foreach (KeyValuePair<string, object> keyValuePair in FirefoxOptionsDict)
            {
                firefoxOptions.AddAdditionalCapability(keyValuePair.Key, keyValuePair.Value);
            }
            firefoxOptions.Profile = (firefoxProfile);
            return firefoxOptions;
        }

        private InternetExplorerOptions CreateInternetExplorerConfig()
        {
  
            InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();
            foreach (KeyValuePair<string, object> keyValuePair in InternetExplorerOptionsDict)
            {
                internetExplorerOptions.AddAdditionalCapability(keyValuePair.Key, keyValuePair.Value);
            }
            return internetExplorerOptions;
        }

        private OperaOptions CreateOperaConfig()
        {
          
            OperaOptions operaOptions = new OperaOptions();
            if (OperaExtensionsList.Count > 0)
            {
                operaOptions.AddExtensions(OperaExtensionsList);
             
            }
            if (OperaArgumentsList.Count > 0)
            {
                operaOptions.AddArguments(OperaArgumentsList);
                
            }
            foreach (KeyValuePair<string, object> keyValuePair in OperaOptionsDict)
            {
                operaOptions.AddAdditionalCapability(keyValuePair.Key, keyValuePair.Value);
            }
            return operaOptions;
        }

        private SafariOptions CreateSafariConfig()
        {
            SafariOptions safariOptions = new SafariOptions();
            foreach (KeyValuePair<string, object> keyValuePair in SafariOptionsDict)
            {
                safariOptions.AddAdditionalCapability(keyValuePair.Key, keyValuePair.Value);
            }
            return safariOptions;
        }

        
    }
}
