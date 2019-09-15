using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SeleniumUITest.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumUITest.Core
{
    [JsonObject]
    public class DriverConfig
    {
        [JsonProperty]
        public string DriverTypeName { get; set; }

        [JsonProperty]
        public string AssemblyName { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public DriverType BrowserValue { get; set; }

        [JsonProperty]
        public string RemoteCapabilities { get; set; }

        [JsonProperty]
        public bool AutoStartRemoteServer { get; set; }
    }
}
