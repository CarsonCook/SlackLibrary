using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.SearchJson.MessageSearchJson
{
    public class JsonSearchMessageMatch
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("channel")]
        public JsonDataId Channel { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("ts")]
        public string Ts { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("permalink")]
        public string Permalink { get; set; }
        [JsonProperty("previous_2")]
        public JsonMessage Previous2 { get; set; }
        [JsonProperty("previous")]
        public JsonMessage Previous { get; set; }
        [JsonProperty("next")]
        public JsonMessage Next { get; set; }
        [JsonProperty("next_2")]
        public JsonMessage Next2 { get; set; }
    }
}