using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamLogsJson
{
    public class JsonTeamLogin
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("date_first")]
        public string TsFirst { get; set; }
        [JsonProperty("date_last")]
        public string TsLast { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
        [JsonProperty("isp")]
        public string Isp { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}