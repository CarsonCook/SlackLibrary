using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel
{
    /**
     * Class used to rename a public or private channel.
     * 
     * Requires the channels:write (public) or groups:write (private) permission.
     */
    public class RenameChannel : SlackApiPost
    {
        private string _channelId, _channelName;
        private bool _isPublicChannel;

        /**
         * @param token - The app Workspace or User token.
         * @param channelId - The ID of the channel to be renamed.
         * @param channelName - The new name for the channel.
         * @param isPublicChannel - Signifies whether the channel is public or private.
         */
        public RenameChannel(string token, string channelId, string channelName, bool isPublicChannel) : base(token)
        {
            _channelId = channelId;
            _channelName = channelName;
            _isPublicChannel = isPublicChannel;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.NAME, _channelName);
            return request;
        }

        protected override string GetApiUrl()
        {
            return _isPublicChannel ? ApiUrls.RENAME_PUBLIC_CHANNEL : ApiUrls.RENAME_PRIVATE_CHANNEL;
        }
    }
}