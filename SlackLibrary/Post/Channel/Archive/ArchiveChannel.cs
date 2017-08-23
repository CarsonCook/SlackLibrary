using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel.Archive
{
    /**
     * Class used to archive a public or private channel.
     * 
     * Requires the channels:write (public) and groups:write (private) permissions.
     */
    public class ArchiveChannel : SlackApiPost
    {
        private string _channelId;
        private bool _isPublicChannel;

        /**
         * @param token - The app Workspace or User token.
         * @param channelId - The ID of the channel to be archived.
         * @param isPublicChannel - Signifies whether the channel is public or private.
         */
        public ArchiveChannel(string token, string channelId, bool isPublicChannel) : base(token)
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
            return _isPublicChannel ? ApiUrls.ARCHIVE_PUBLIC_CHANNEL : ApiUrls.ARCHIVE_PRIVATE_CHANNEL;
        }
    }
}