using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.IdentityJson
{
    public class JsonIdentityResponse : SlackApiResponse
    {
        [JsonProperty("user")]
        public JsonUserIdentity User { get; set; }
        [JsonProperty("team")]
        public JsonDataId Team { get; set; }
    }
}