using Newtonsoft.Json;
namespace SlackITSupport.SlackLibrary.JsonParsing.ListJson.ReactionJson
{
    public class JsonReactionDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("users")]
        public string[] Users { get; set; }
    }
}