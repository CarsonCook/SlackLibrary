using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class SlackApiResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}