using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ListJson.ReactionJson
{
    public class JsonReactionItem : JsonItem
    {
        [JsonProperty("reactions")]
        public JsonReactionDetails[] Reactions { get; set; }
    }
}