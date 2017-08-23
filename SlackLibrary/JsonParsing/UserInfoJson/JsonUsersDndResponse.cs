using Newtonsoft.Json;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUsersDndResponse : SlackApiResponse
    {
        [JsonProperty("users")]
        public Dictionary<string, JsonUserDndResponse> Users { get; set; }
    }
}