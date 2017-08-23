using Newtonsoft.Json;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.JsonParsing
{
    public class JsonEmoji : SlackApiResponse
    {
        [JsonProperty("emoji")]
        public Dictionary<string,string> Emojis { get; set; }
    }
}