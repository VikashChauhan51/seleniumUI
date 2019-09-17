using Newtonsoft.Json;

namespace SeleniumUITest.Core
{
    [JsonObject]
    public class EnvironmentConfig
    {
        [JsonProperty]
        public string Url { get; set; }
        [JsonProperty]
        public int DefaultWaitTime { get; set; }
        [JsonProperty]
        public bool CaptureWebServerOutput { get; set; }
        [JsonProperty]
        public bool HideWebServerCommandPrompt { get; set; }
        [JsonProperty]
        public bool TakeScreenshot { get; set; }
        [JsonProperty]
        public DriverConfig Config { get; set; }

    }
}
