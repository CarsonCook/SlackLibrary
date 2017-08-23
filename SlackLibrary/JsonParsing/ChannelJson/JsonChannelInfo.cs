using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonChannelInfo
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
        [JsonProperty("last_set")]
        public string LastSet { get; set; }
    }
}