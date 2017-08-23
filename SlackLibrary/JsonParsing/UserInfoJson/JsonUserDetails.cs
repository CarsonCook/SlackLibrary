using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUserDetails : JsonDataId
    {
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("real_name")]
        public string RealName { get; set; }
        [JsonProperty("tz")]
        public string Timezone { get; set; }
        [JsonProperty("tz_label")]
        public string TzLabel { get; set; }
        [JsonProperty("tz_offset")]
        public float TzOffset { get; set; }
        [JsonProperty("profile")]
        public JsonUserProfile Profile { get; set; }
        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("is_owner")]
        public bool IsOwner { get; set; }
        [JsonProperty("is_primaryOwner")]
        public bool IsPrimaryOwner { get; set; }
        [JsonProperty("is_restricted")]
        public bool IsRestricted { get; set; }
        [JsonProperty("is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }
        [JsonProperty("updated")]
        public long Updated { get; set; }
        [JsonProperty("has_2fa")]
        public bool Has2Fa { get; set; }
        [JsonProperty("two_factor_type")]
        public string Type2Fa { get; set; }
    }
}