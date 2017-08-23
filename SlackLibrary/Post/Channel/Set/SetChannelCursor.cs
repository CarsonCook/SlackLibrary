using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Set
{
    /**
     * Class used to set where the reading cursor in a channel is.
     * When a user is outside of that channel, messages under the 
     * given one will be considered unread.
     * 
     * Requires the im:write (direct), mpim:write (multi direct),  
     * groups:write (private) and channels:write (public) permissions.
     */
    public class SetChannelCursor : SlackApiPost
    {
        private string _channelId, _ts;
        private ChannelType _channelType;

        /**
         * @param token - The app Bot or User token.
         * @param channelId - The ID of the channel that will have its cursor set.
         * @param ts - The timestamp of the message to set the cursor at.
         * @param channelType - Signifies what kind of channel is being set.
         */
        public SetChannelCursor(string token, string channelId, string ts, ChannelType channelType) : base(token)
        {
            _channelId = channelId;
            _ts = ts;
            _channelType = channelType;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.TS, _ts);
            return request;
        }

        protected override string GetApiUrl()
        {
            switch (_channelType)
            {
                case ChannelType.DIRECT:
                    return ApiUrls.SET_DIRECT_CHANNEL_CURSOR;
                case ChannelType.MULTI_DIRECT:
                    return ApiUrls.SET_MULTI_DIRECT_CHANNEL_CURSOR;
                case ChannelType.PRIVATE:
                    return ApiUrls.SET_PRIVATE_CHANNEL_CURSOR;
                case ChannelType.PUBLIC:
                    return ApiUrls.SET_PUBLIC_CHANNEL_CURSOR;
            }
            return ""; //bad ChannelType passed in
        }
    }
}