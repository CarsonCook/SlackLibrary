using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamProfileJson
{
    public class JsonTeamProfileOptions
    {
        [JsonProperty("is_protected")]
        public int IsProtected { get; set; }
    }
}