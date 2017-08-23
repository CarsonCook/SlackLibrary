using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.MessageJson
{
    public class JsonMessageAction
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("options")]
        public JsonMessageActionOption[] Options;
    }
}