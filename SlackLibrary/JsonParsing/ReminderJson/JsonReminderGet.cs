using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ReminderJson
{
    public class JsonReminderGet : SlackApiResponse
    {
        [JsonProperty("reminder")]
        public JsonReminder Reminder { get; set; }
    }
}