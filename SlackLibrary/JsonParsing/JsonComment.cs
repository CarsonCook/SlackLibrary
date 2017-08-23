using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class JsonComment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("timestamp")]
        public string Ts { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}