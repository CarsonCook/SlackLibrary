using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson
{
    public class JsonTeamGet:SlackApiResponse
    {
        [JsonProperty("team")]
        public JsonTeam Team { get; set; }
    }
}