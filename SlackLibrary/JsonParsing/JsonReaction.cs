using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class JsonReaction : SlackApiResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("message")]
        public JsonMessage Message { get; set; }
    }
}