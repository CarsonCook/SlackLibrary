using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing;

namespace SlackITSupport.SlackLibrary.MessageJson
{
    public class JsonTeam : JsonDataId
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }
    }
}