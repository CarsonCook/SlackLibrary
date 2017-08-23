using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonChannelDirect
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("is_im")]
        public bool IsIm { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("created")]
        public string Created { get; set; }
        [JsonProperty("is_user_deleted")]
        public bool IsUserDeleted { get; set; }
    }
}