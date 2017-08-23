using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUser : SlackApiResponse
    {
        [JsonProperty("user")]
        public JsonUserDetails User { get; set; }
    }
}