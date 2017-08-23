using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonGetChannels : SlackApiResponse
    {
        [JsonProperty("channels")]
        public JsonChannelPublic[] Channels { get; set; }
        [JsonProperty("ims")]
        public JsonChannelDirect[] Ims { get; set; }
        [JsonProperty("groups")]
        public JsonChannelPrivate[] Groups { get; set; }
    }
}