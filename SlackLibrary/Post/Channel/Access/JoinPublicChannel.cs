using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Access
{
    /**
     * Class used to join a channel. If a channel by the given name does not exist,
     * one will be made.
     * 
     * Requires the channels:write permission.
     */
    public class JoinPublicChannel : SlackApiPost
    {
        private string _channelName;

        /**
         * @param token - The app User token.
         * @param channelName - The name of the channel to join.
         */
        public JoinPublicChannel(string token, string channelName) : base(token)
        {
            _channelName = channelName;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.NAME, _channelName);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.JOIN_PUBLIC_CHANNEL;
        }
    }
}