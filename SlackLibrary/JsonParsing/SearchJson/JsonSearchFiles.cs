using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.SearchJson.MessageSearchJson;
using SlackITSupport.SlackLibrary.SearchJson.FileJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.SearchJson
{
    public class JsonSearchFiles : JsonSearchCount
    {
        [JsonProperty("matches")]
        JsonFile[] Matches { get; set; }
    }
}