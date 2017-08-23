using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserGroupsJson
{
    public class JsonUserGroupsResponse:SlackApiResponse
    {
        [JsonProperty("usergroups")]
        public JsonUserGroup[] UserGroups { get; set; }
    }
}