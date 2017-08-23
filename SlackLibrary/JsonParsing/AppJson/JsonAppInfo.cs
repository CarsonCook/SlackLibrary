using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.AppJson
{
    public class JsonAppInfo
    {
        [JsonProperty("team")]
        public JsonAppScopeResources Team { get; set; }
        [JsonProperty("channel")]
        public JsonAppScopeResources Channel { get; set; }
        [JsonProperty("group")]
        public JsonAppScopeResources Group { get; set; }
        [JsonProperty("mpim")]
        public JsonAppScopeResources Mpim { get; set; }
        [JsonProperty("im")]
        public JsonAppScopeResources Im { get; set; }
        [JsonProperty("app_home")]
        public JsonAppScopeResources AppHome { get; set; }
    }
}