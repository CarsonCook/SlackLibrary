using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Create
{
    /**
     * Class used to create a channel.
     * 
     * Requires the channels:write (public) and groups:write (private) permissions.
     */
    public class CreateChannel : SlackApiPost
    {
        private string _channelName;
        private bool _isPublicChannel;

        /**
         * @param token - The app Workspace or User token.
         * @param channelName - The name of the channel to be made.
         * @param isPublicChannel - Signifies if the channel is public or private.
         */
        public CreateChannel(string token, string channelName, bool isPublicChannel) : base(token)
        {
            _channelName = channelName;
            _isPublicChannel = isPublicChannel;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.NAME, _channelName);
            return request;
        }

        protected override string GetApiUrl()
        {
            return _isPublicChannel ? ApiUrls.CREATE_PUBLIC_CHANNEL : ApiUrls.CREATE_PRIVATE_CHANNEL;
        }
    }
}