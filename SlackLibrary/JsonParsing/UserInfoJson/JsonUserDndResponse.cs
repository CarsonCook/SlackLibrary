using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson
{
    public class JsonUserDndResponse : SlackApiResponse
    {
        [JsonProperty("dnd_enabled")]
        public bool DndEnabled { get; set; }
        [JsonProperty("next_dnd_start_ts")]
        public string NextDndStartTs { get; set; }
        [JsonProperty("next_dnd_end_ts")]
        public string NextDndEndTs { get; set; }
        [JsonProperty("snooze_enabled")]
        public bool SnoozeEnabled { get; set; }
        [JsonProperty("snooze_endtime")]
        public string SnoozeEndTs { get; set; }
        [JsonProperty("snooze_remaining")]
        public string SnoozeRemaing { get; set; }
    }
}