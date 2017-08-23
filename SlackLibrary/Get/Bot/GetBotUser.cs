using SlackITSupport.SlackLibrary.JsonParsing.BotJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Bot
{
    /**
     * Class that retrieves information on a bot user in Slack.
     * 
     * Requires the users:read permission.
     */
    public class GetBotUser : SlackApiGet<JsonBot>
    {
        private string _botId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The User or Workspace token of the app.
         * @param botId - The ID of the bot user to get.
         */
        public GetBotUser(string token, string botId) : base(token)
        {
            _botId = botId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.BOT, _botId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_BOT_USER;
        }
    }
}