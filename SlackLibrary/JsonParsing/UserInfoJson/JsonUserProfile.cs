using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUserProfile : JsonPicture
    {
        [JsonProperty("avator_hash")]
        public string AvatarHash { get; set; }
        [JsonProperty("current_status")]
        public string CurrentStatus { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("real_name")]
        public string RealName { get; set; }
        [JsonProperty("tz")]
        public string Tz { get; set; }
        [JsonProperty("tz_label")]
        public string TzLabel { get; set; }
        [JsonProperty("tz_offset")]
        public string TzOffset { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("skype")]
        public string Skype { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}