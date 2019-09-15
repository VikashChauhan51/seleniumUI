using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    [JsonObject]
    public class WebsiteConfig
    {
        [JsonProperty]
        public string Protocol { get; set; }

        [JsonProperty]
        public string HostName { get; set; }

        [JsonProperty]
        public string Port { get; set; }

        [JsonProperty]
        public string SecurePort { get; set; }

        [JsonProperty]
        public string Folder { get; set; }
    }
}
