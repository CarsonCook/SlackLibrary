using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.MessageJson
{
    public class JsonMessageReaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("users")]
        public string[] Users { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}