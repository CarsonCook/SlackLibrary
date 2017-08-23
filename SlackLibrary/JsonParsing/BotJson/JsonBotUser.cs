using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.BotJson
{
    public class JsonBotUser : JsonDataId
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [JsonProperty("icons")]
        public JsonPicture Icons { get; set; }
    }
}