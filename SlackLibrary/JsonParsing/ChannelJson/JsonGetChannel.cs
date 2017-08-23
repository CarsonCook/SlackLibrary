using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonGetChannel : SlackApiResponse
    {
        [JsonProperty("channel")]
        public JsonChannelPublic PublicChannel { get; set; }
        [JsonProperty("group")]
        public JsonChannelPrivate PrivateChannel { get; set; }
    }
}