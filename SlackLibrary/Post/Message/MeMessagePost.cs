using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Message
{
    /**
     * Class used to send a me message from the authenticated user to a given channel.
     * This is pretty much just a normal message but italicized.
     * 
     * Requires the chat:write:user permission.
     */
    public class MeMessagePost : SlackApiPost
    {
        private string _channelId, _text;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channelId - The ID of the channel the me message will be posted to.
         * @param text - The text of the me message.
         */
        public MeMessagePost(string token, string channelId, string text) : base(token)
        {
            _channelId = channelId;
            _text = text;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.TEXT, _text);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.POST_ME_MESSAGE;
        }
    }
}