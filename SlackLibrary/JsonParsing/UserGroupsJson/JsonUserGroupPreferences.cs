using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserGroupsJson
{
    public class JsonUserGroupPreferences
    {
        [JsonProperty("channels")]
        public string[] Channels { get; set; }
        [JsonProperty("groups")]
        public string[] Groups { get; set; }
    }
}