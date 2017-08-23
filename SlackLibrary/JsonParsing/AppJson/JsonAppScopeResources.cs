using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.AppJson
{
    public class JsonAppScopeResources
    {
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
        [JsonProperty("resources")]
        public JsonAppResources Resources { get; set; }
    }
}