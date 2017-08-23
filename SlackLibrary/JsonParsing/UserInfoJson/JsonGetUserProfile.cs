using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonGetUserProfile:SlackApiResponse
    {
        [JsonProperty("profile")]
        public JsonUserProfile Profile { get; set; }
    }
}