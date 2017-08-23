using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamLogsJson
{
    public class JsonIntegrationLogsResponse : SlackApiResponse
    {
        [JsonProperty("logs")]
        public JsonIntegrationLog[] Logs { get; set; }
        [JsonProperty("paging")]
        public JsonPaging Paging { get; set; }
    }
}