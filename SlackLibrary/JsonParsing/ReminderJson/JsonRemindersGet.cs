using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.ReminderJson
{
    public class JsonRemindersGet:SlackApiResponse
    {
        [JsonProperty("reminders")]
        public JsonReminder[] Reminders;
    }
}