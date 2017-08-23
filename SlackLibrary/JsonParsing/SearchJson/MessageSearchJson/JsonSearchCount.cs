using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.SearchJson.MessageSearchJson
{
    public class JsonSearchCount
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("paging")]
        public JsonPaging Paging { get; set; }
    }
}