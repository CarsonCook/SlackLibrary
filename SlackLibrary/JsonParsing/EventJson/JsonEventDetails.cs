using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.EventJson
{
    public class JsonEventDetails
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("thread_ts")]
        public string Thread_ts { get; set; }
        [JsonProperty("ts")]
        public string Ts { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("parent_user_id")]
        public string Parent_user_id { get; set; }
        [JsonProperty("subtype")]
        public string Subtype { get; set; }
        [JsonProperty("reaction")]
        public string Reaction { get; set; }
        [JsonProperty("item")]
        public JsonEventItem Item { get; set; }
    }
}