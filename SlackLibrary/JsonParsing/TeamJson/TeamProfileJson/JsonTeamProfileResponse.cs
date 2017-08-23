using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamProfileJson
{
    public class JsonTeamProfileResponse : SlackApiResponse
    {
        [JsonProperty("profile")]
        public JsonTeamProfile Profile { get; set; }
    }
}