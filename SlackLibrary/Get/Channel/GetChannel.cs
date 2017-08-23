using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    /**
     * Class that retrieves a public or private channel.
     * 
     * Requires the groups:read and channels:read permissions.
     */
    public class GetChannel : SlackApiGet<JsonGetChannel>
    {
        private string _channelId;
        private ChannelType _channelType;

        /**
         * The ItemType is arbitrary and does not matter. The parent class requires it to be passed into it's constructor,
         * but it is not used.
         * 
         * @param token - The Bot, Workspace or User token of the app.
         * @param channelId - The ID of the channel being retrieved.
         * @param channelType - Signifies whether the channel is public or private.
         */
        public GetChannel(string token, string channelId, ChannelType channelType) : base(token)
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
                case ChannelType.PUBLIC:
                    return ApiUrls.GET_CHANNEL_PUBLIC;
                case ChannelType.PRIVATE:
                    return ApiUrls.GET_CHANNEL_PRIVATE;
            }
            return "";
        }
    }
}