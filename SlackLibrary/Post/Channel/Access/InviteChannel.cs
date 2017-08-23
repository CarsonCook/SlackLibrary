using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel.Access
{
    /**
     * Class used to invite a given user to a given private or public channel.
     * 
     * Requries the channels:write (public) and groups:write (private) permission.
     */
    public class InviteChannel : SlackApiPost
    {
        private string _channelId, _userId;
        private bool _isPublicChannel;

        /**
         * @param token - The app Workspace or User token.
         * @param channelId - The ID of the channel to invite a user to.
         * @param userId - The ID of the user to be invited.
         * @param isPublicChannel - Signifies if the channel is public or private.
         */
        public InviteChannel(string token, string channelId, string userId, bool isPublicChannel) : base(token)
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
            return _isPublicChannel ? ApiUrls.INVITE_PUBLIC_CHANNEL : ApiUrls.INVITE_PRIVATE_CHANNEL;
        }
    }
}