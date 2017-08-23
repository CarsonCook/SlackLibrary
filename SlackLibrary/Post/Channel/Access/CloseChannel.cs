using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Channel.Access
{
    /**
     * Class used to close a direct, multi direct or private channel.
     * Close means users on that channel will be directed to another channel.
     * 
     * Requires the im:write (direct), mpim:write (multi direct) and 
     * groups:write (private) permissions.
     */
    public class CloseChannel : SlackApiPost
    {
        private ChannelType _channelType;
        private string _channelId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channelId - The ID of the channel to be closed.
         * @param channelType - Signifies if the channel is private, multi direct or direct.
         */
        public CloseChannel(string token, string channelId, ChannelType channelType) : base(token)
        {
            _channelId = channelId;
            _channelType = channelType;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            return request;
        }

        protected override string GetApiUrl()
        {
            switch (_channelType)
            {
                case ChannelType.DIRECT:
                    return ApiUrls.CLOSE_DIRECT_CHANNEL;
                case ChannelType.MULTI_DIRECT:
                    return ApiUrls.CLOSE_MULTI_DIRECT_CHANNEL;
                case ChannelType.PRIVATE:
                    return ApiUrls.CLOSE_PRIVATE_CHANNEL;
            }
            return ""; //bad ChannelType passed in
        }
    }
}