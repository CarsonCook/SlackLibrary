using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.EventJson
{
    public class JsonEvent :SlackApiResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("team_id")]
        public string Team_id { get; set; }
        [JsonProperty("api_app_id")]
        public string Api_app_id { get; set; }
        [JsonProperty("event")]
        public JsonEventDetails Event { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("authed_users")]
        public string[] Authed_users { get; set; }
        [JsonProperty("event_id")]
        public string Event_id { get; set; }
        [JsonProperty("event_time")]
        public long Event_time { get; set; }
    }
}