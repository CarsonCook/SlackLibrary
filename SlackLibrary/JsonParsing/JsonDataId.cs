using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class JsonDataId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}