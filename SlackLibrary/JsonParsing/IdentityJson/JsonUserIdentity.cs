using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.IdentityJson
{
    public class JsonUserIdentity : JsonPicture
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}