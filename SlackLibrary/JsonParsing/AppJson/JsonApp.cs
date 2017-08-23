using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.AppJson
{
    public class JsonApp : SlackApiResponse
    {
        [JsonProperty("info")]
        public JsonAppInfo Info { get; set; }
    }
}