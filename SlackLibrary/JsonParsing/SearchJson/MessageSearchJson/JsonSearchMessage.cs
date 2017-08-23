using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.SearchJson.MessageSearchJson
{
    public class JsonSearchMessages : JsonSearchCount
    {
        [JsonProperty("matches")]
        public JsonSearchMessageMatch[] Matches { get; set; }
    }
}