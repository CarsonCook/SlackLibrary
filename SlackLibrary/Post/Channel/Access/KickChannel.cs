using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel.Access
{
    /**
     * Class used to remove another user from a public or private channel.
     * 
     * Requires the channels:write (public) and groups:write (private) permissions.
     */
    public class KickChannel : SlackApiPost
    {
        private string _channelId, _userId;
        private bool _isPublicChannel;

        /**
         * @param token - The app Workspace or User token.
         * @param channelId - The ID of the channel the user will be removed from.
         * @param userId - The ID of the user to be removed.
         * @param isPublicChannel - Signifies if the channel the user is removed from is public or private.
         */
        public KickChannel(string token, string channelId, string userId, bool isPublicChannel) : base(token)
        {
            _channelId = channelId;
            _userId = userId;
            _isPublicChannel = isPublicChannel;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return _isPublicChannel ? ApiUrls.KICK_PUBLIC_CHANNEL : ApiUrls.KICK_PRIVATE_CHANNEL;
        }
    }
}