using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.SearchJson.FileJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.FileJson
{
    public class JsonFilesResponse : SlackApiResponse
    {
        [JsonProperty("files")]
        public JsonFile[] Files { get; set; }
        [JsonProperty("paging")]
        public JsonPaging Paging { get; set; }
    }
}