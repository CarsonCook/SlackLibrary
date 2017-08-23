using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.MessageJson
{
    public class JsonMessageActionOption
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}