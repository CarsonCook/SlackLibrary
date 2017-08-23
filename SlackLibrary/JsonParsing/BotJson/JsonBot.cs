using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.BotJson
{
    public class JsonBot : SlackApiResponse
    {
        [JsonProperty("bot")]
        public JsonBotUser Bot { get; set; }
    }
}