using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUserPresence:SlackApiResponse
    {
        [JsonProperty("presence")]
        public string Presence { get; set; }
        [JsonProperty("online")]
        public bool Online { get; set; }
        [JsonProperty("auto_away")]
        public bool AutoAway { get; set; }
        [JsonProperty("manual_away")]
        public bool ManualAway { get; set; }
        [JsonProperty("connection_count")]
        public int ConnectionCount { get; set; }
        [JsonProperty("last_activity")]
        public double LastActivity { get; set; }
    }
}