using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserGroupsJson
{
    public class JsonUserGroup:JsonDataId
    {
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
        [JsonProperty("is_usergroup")]
        public bool IsUsergroup { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("Handle")]
        public string Handle { get; set; }
        [JsonProperty("is_external")]
        public bool IsExternal { get; set; }
        [JsonProperty("date_create")]
        public double DateCreated { get; set; }
        [JsonProperty("date_update")]
        public double DateUpdated { get; set; }
        [JsonProperty("date_delete")]
        public double DateDeleted { get; set; }
        [JsonProperty("auto_type")]
        public string AutoType { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("updated_by")]
        public string UpdatedBy { get; set; }
        [JsonProperty("DeletedBy")]
        public string DeletedBy { get; set; }
        [JsonProperty("prefs")]
        public JsonUserGroupPreferences Prefs { get; set; }
        [JsonProperty("user_count")]
        public string UserCount { get; set; }
        [JsonProperty("users")]
        public string[] Users { get; set; }
    }
}