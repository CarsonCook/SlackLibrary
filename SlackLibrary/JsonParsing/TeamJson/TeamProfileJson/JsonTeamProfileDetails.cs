using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamProfileJson
{
    public class JsonTeamProfileDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("ordering")]
        public int Ordering { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("hint")]
        public string Hint { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("possible_values")]
        public string[] PossibleValues { get; set; }
        [JsonProperty("options")]
        public JsonTeamProfileOptions Options { get; set; }
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }
    }
}