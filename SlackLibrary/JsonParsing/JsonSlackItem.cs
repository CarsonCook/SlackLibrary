using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class JsonSlackItem
    {
        [JsonProperty("permalink")]
        public string Permalink { get; set; }
        [JsonProperty("pinned_to")]
        public string[] PinnedTo { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("is_starred")]
        public bool IsStarred { get; set; }
        [JsonProperty("reactions")]
        public JsonMessageReaction[] Reactions { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
    }
}