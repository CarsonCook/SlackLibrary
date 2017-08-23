using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.SearchJson.MessageSearchJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.SearchJson
{
    public class JsonSearch : SlackApiResponse
    {
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("messages")]
        public JsonSearchMessages Messages { get; set; }
        [JsonProperty("files")]
        public JsonSearchFiles Files { get; set; }
    }
}