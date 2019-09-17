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
        [JsonConverter(typeof(StringEnumConverter))]
        public DriverType Driver { get; set; }
        [JsonProperty]
        public  List<string> ArgumentsList { get; set; }
        [JsonProperty]
        public List<string> ExtensionsList { get; set; }
        [JsonProperty]
        public Dictionary<string, object> AdditionalCapability { get; set; }
        [JsonProperty]
        public Dictionary<string, object> UserProfilePreferences { get; set; }
        [JsonProperty]
        public bool AutoStartRemoteServer { get; set; }
        [JsonProperty]
        public bool UseDefaultDriverOptionsOnly { get; set; }
    }
}
