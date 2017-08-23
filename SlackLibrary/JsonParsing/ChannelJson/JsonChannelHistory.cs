using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonChannelHistory:SlackApiResponse
    {
        [JsonProperty("latest")]
        public string Latest { get; set; }
        [JsonProperty("messages")]
        public JsonMessage[] Messages { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
    }
}