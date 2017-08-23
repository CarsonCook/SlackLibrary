using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserGroupsJson
{
    public class JsonGetUsersInGroup : SlackApiResponse
    {
        [JsonProperty("users")]
        public string[] Users { get; set; }
    }
}