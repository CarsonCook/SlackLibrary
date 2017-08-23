using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Archive
{
    /**
     * Class used to unarchive a private or public channel.
     * 
     * Requires the channels:write (public) and groups:write (private) permissions.
     */
    public class UnArchiveChannel : SlackApiPost
    {
        private string _channelId;
        private bool _isPublicChannel;

        /**
         * @param token - The app Workspace or User token.
         * @param channelId - The ID of the channel to be unarchived.
         * @param isPublicChannel - Signifies if the channel is public or private.
         */
        public UnArchiveChannel(string token, string channelId, bool isPublicChannel) : base(token)
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
            return _isPublicChannel ? ApiUrls.UNARCHIVE_PUBLIC_CHANNEL : ApiUrls.UNARCHIVE_PRIVATE_CHANNEL;
        }
    }
}