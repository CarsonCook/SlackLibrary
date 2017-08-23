using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel.Access
{
    /**
     * Class used to leave a public or private channel.
     * 
     * Requires the groups:write (private) and channels:write (public) permissions.
     */
    public class LeaveChannel : SlackApiPost
    {
        private string _channelId;
        private bool _isPublicChannel;

        /**
         * @param token - The app User token.
         * @param channelid - The ID of the channel to leave.
         * @param isPublicChannel - Signifies if the channel to be left is public or private.
         */
        public LeaveChannel(string token, string channelId, bool isPublicChannel) : base(token)
        {
            _channelId = channelId;
            _isPublicChannel = isPublicChannel;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return _isPublicChannel ? ApiUrls.LEAVE_PUBLIC_CHANNEL : ApiUrls.LEAVE_PRIVATE_CHANNEL;
        }
    }
}