using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Web;

namespace SlackITSupport.SlackLibrary.MessageJson
{
    public class JsonSlashResponseReply : SlackApiResponse
    {
        [JsonProperty("actions")]
        public JsonMessageAction[] Actions { get; set; } //as of right now, will only ever receive one action
        public JsonMessageAction GetAction()
        {
            return Actions[0];
        }
        [JsonProperty("callback_id")]
        public string Callback_id { get; set; }
        [JsonProperty("team")]
        public JsonTeam Team { get; set; }
        [JsonProperty("channel")]
        public JsonDataId Channel { get; set; }
        [JsonProperty("user")]
        public JsonDataId User { get; set; }
        [JsonProperty("action_ts")]
        public double Action_ts { get; set; }
        [JsonProperty("message_ts")]
        public double Message_ts { get; set; }
        [JsonProperty("attachment_id")]
        public string Attachment_id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("is_app_unfurl")]
        public bool Is_App_Unfurl { get; set; }
        [JsonProperty("response_url")]
        public string Response_url { get; set; }
        [JsonProperty("original_message")]
        public JsonMessage OriginalMessage { get; set; }

        public static JsonSlashResponseReply GetMessageJson(string jsonString)
        {
            jsonString = HttpUtility.UrlDecode(jsonString); //turn url encoded string into readable payload=JSON string
            jsonString = jsonString.Replace(Constants.MESSAGE_JSON_PREFIX, ""); //get pure json string to parse into classes
            return JsonConvert.DeserializeObject<JsonSlashResponseReply>(jsonString);
        }
    }
}