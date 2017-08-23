using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ListJson
{
    public class JsonListResponse : SlackApiResponse
    {
        [JsonProperty("items")]
        public JsonItem[] Items { get; set; }
    }
}