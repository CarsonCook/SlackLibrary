using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel.Set
{
    /**
     * Class used to set a public or private channel's purpose.
     * 
     * Requires the groups:write (private) and channels:write (public) permissions.
     */
    public class SetChannelPurpose : SlackApiPost
    {
        private string _channelId, _purpose;
        private bool _isPublicChannel;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channeId - The ID of the channel that will have its purpose set.
         * @param purpose - The purpose to be set.
         * @param isPublicChannel - Signifies if the channel is public or private.
         */
        public SetChannelPurpose(string token, string channelId, string purpose, bool isPublicChannel) : base(token)
        {
            _purpose = purpose;
            _channelId = channelId;
            _isPublicChannel = isPublicChannel;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.PURPOSE, _purpose);
            return request;
        }

        protected override string GetApiUrl()
        {
            return _isPublicChannel ? ApiUrls.SET_PUBLIC_CHANNEL_PURPOSE : ApiUrls.SET_PRIVATE_CHANNEL_PURPOSE;
        }
    }
}