using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ListJson
{
    public class JsonListPagingResponse : JsonListResponse
    {
        [JsonProperty("paging")]
        public JsonPaging Paging { get; set; }
    }
}