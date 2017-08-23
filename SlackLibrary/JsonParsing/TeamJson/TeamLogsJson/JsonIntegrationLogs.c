using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamLogsJson
{
    public class JsonIntegrationLog
    {
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_name")]
        public string Username { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("change_type")]
        public string ChangeType { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        [JsonProperty("app_type")]
        public string AppType { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}