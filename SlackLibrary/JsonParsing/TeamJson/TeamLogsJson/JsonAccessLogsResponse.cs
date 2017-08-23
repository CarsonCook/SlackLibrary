using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamLogsJson
{
    public class JsonAccessLogsResponse : SlackApiResponse
    {
        [JsonProperty("logins")]
        public JsonTeamLogin[] Logings { get; set; }
        [JsonProperty("paging")]
        public JsonPaging Paging { get; set; }
    }
}