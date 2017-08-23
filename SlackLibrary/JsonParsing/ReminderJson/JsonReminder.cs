using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ReminderJson
{
    public class JsonReminder
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("creator")]
        public string CreatorId { get; set; }
        [JsonProperty("user")]
        public string UserId { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("recurring")]
        public bool Recurring { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("complete_ts")]
        public string CompleteTs { get; set; }
    }
}