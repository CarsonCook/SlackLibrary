using Newtonsoft.Json;
namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamProfileJson
{
    public class JsonTeamProfile
    {
        [JsonProperty("fields")]
        public JsonTeamProfileDetails[] Fields { get; set; }
    }
}