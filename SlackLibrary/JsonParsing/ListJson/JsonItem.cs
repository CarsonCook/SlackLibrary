using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;
using SlackITSupport.SlackLibrary.SearchJson.FileJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.ListJson
{
    public class JsonItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("created")]
        public string Created { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("file")]
        public JsonFile File { get; set; }
        [JsonProperty("comment")]
        public JsonMessage Comment { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("message")]
        public JsonMessage Message { get; set; }
    }
}