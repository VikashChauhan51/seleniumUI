using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    [JsonObject]
    class TestConfig
    {
        [JsonProperty]
        public bool CaptureWebServerOutput { get; set; }

        [JsonProperty]
        public bool HideWebServerCommandPrompt { get; set; }

        [JsonProperty]
        public string DriverServiceLocation { get; set; }

        [JsonProperty]
        public string ActiveDriverConfig { get; set; }

        [JsonProperty]
        public string ActiveWebsiteConfig { get; set; }

        [JsonProperty]
        public Dictionary<string, WebsiteConfig> WebSiteConfigs { get; set; }

        [JsonProperty]
        public Dictionary<string, DriverConfig> DriverConfigs { get; set; }
    }
}
