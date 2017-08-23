using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.MessageJson
{
    public class JsonThreadResponse : SlackApiResponse
    {
        [JsonProperty("messages")]
        public JsonMessage[] Messages { get; set; }
    }
}