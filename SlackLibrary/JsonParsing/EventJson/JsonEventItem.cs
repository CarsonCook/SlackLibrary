using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.EventJson
{
    public class JsonEventItem
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("file")]
        public string File { get; set; }
        [JsonProperty("file_comment")]
        public string FileComment { get; set; }
        [JsonProperty("ts")]
        public string Ts { get; set; }
    }
}