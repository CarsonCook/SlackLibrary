using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class JsonPaging
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
    }
}