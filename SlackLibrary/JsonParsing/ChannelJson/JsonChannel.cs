using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;

namespace SlackITSupport.SlackLibrary.JsonParsing.ChannelJson
{
    public class JsonChannel : JsonDataId
    {
        [JsonProperty("created")]
        public string Created { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }
        [JsonProperty("members")]
        public string[] Members { get; set; }
        [JsonProperty("topic")]
        public JsonChannelInfo Topic { get; set; }
        [JsonProperty("purpose")]
        public JsonChannelInfo Purpose { get; set; }
        [JsonProperty("last_read")]
        public string LastRead { get; set; }
        [JsonProperty("latest")]
        public JsonMessage Latest { get; set; }
        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }
        [JsonProperty("unread_count_display")]
        public int UnreadCountDisplay { get; set; }
    }
}