using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonChannelPrivate : JsonChannel
    {
        [JsonProperty("is_group")]
        public bool IsGroup { get; set; }
        [JsonProperty("is_mpim")]
        public bool IsMpim { get; set; }
    }
}