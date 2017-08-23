using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.AppJson
{
    public class JsonAppResources
    {
        [JsonProperty("ids")]
        public string[] Ids { get; set; }
        [JsonProperty("wildcard")]
        public bool Wildcard { get; set; }
        [JsonProperty("excluded_ids")]
        public string[] ExcludedIds { get; set; }
    }
}