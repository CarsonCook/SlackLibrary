using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Set
{
    /**
     * Class used to set the topic of a public or private channel.
     * 
     * Requires the groups:write (private) and channels:write (public) permission.
     */
    public class SetChannelTopic : SlackApiPost
    {
        private string _channelId, _topic;
        private bool _isPublicChannel;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channeId - The ID of the channel that will have its topic set.
         * @param topic - The topic to be set.
         * @param isPublicChannel - Signifies if the channel is public or private.
         */
        public SetChannelTopic(string token, string channelId, string topic, bool isPublicChannel) : base(token)
        {
            _channelId = channelId;
            _topic = topic;
            _isPublicChannel = isPublicChannel;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.TOPIC, _topic);
            return request;
        }

        protected override string GetApiUrl()
        {
            return _isPublicChannel ? ApiUrls.SET_PUBLIC_CHANNEL_TOPIC : ApiUrls.SET_PRIVATE_CHANNEL_TOPIC;
        }
    }
}