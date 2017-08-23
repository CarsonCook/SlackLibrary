using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing;

namespace SlackITSupport.SlackLibrary.JsonParsing.MessageJson
{
    public class JsonMessage : JsonSlackItem
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("as_user")]
        public bool AsUser { get; set; }
        [JsonProperty("attachments")]
        public JsonMessageAttachment[] Attachments { get; set; }
        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        [JsonProperty("link_names")]
        public bool LinkNames { get; set; }
        [JsonProperty("parse")]
        public string Parse { get; set; }
        [JsonProperty("reply_broadcast")]
        public bool ReplyBroadcast { get; set; }
        [JsonProperty("thread_ts")]
        public string ThreadTs { get; set; }
        [JsonProperty("unfurl_links")]
        public bool UnfurlLinks { get; set; }
        [JsonProperty("unfurl_media")]
        public bool UnfurlMedia { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("parent_user_id")]
        public string Parent_user_id { get; set; }
        [JsonProperty("last_read")]
        public string Last_read { get; set; }
        [JsonProperty("unread_count")]
        public int Unread_count { get; set; }
    }
}