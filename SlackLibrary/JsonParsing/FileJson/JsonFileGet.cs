using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.SearchJson.FileJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.FileJson
{
    public class JsonFileGet : SlackApiResponse
    {
        [JsonProperty("file")]
        public JsonFile Id { get; set; }
        [JsonProperty("comemnts")]
        public JsonComment[] Comments { get; set; }
        [JsonProperty("paging")]
        public JsonPaging Paging { get; set; }
    }
}