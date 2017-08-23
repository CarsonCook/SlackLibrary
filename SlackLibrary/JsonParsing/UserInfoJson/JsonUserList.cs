using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUserList : SlackApiResponse
    {
        [JsonProperty("members")]
        public JsonUserDetails[] Members { get; set; }
        [JsonProperty("cache_ts")]
        public double CacheTs { get; set; }
    }
}