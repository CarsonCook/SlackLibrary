using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson
{
    public class JsonTeam : JsonDataId
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("email_domain")]
        public string EmailDomain { get; set; }
        [JsonProperty("icon")]
        public JsonTeamIcon Icon { get; set; }
        [JsonProperty("enterprise_id")]
        public string EnterpriseId { get; set; }
        [JsonProperty("enterprise_name")]
        public string EnterpriseName { get; set; }
    }
}