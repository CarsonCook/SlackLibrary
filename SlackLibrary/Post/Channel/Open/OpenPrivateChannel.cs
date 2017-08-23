using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Open
{
    /**
     * Class used to open a private channel. This means that
     * the channel will be put into view, it won't create a new one.
     * 
     * Requires the groups:write permission.
     */
    public class OpenPrivateChannel : SlackApiPost
    {
        private string _channelId;

        /**
         * @param token - The app Bot or User token.
         * @param channelId - The ID of the private channel to open.
         */
        public OpenPrivateChannel(string token, string channelId) : base(token)
        {
            _channelId = channelId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.OPEN_PRIVATE_CHANNEL;
        }
    }
}