using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonChannelPublic : JsonChannel
    {
        [JsonProperty("is_channel")]
        public bool IsChannel { get; set; }
        [JsonProperty("is_general")]
        public bool IsGeneral { get; set; }
        [JsonProperty("is_member")]
        public bool IsMember { get; set; }
    }
}