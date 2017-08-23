using System.Collections.Generic;
using SlackITSupport.SlackLibrary;
using SlackITSupport.SlackLibrary.SlackConstants;
using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;

namespace SlackITSupport.Models.SlackLibrary.Events.Search
{
    /**
     * Class that retrieves messages from a given time period in a given Slack channel.
     * 
     * Requires the channels:history, groups:history, im:history and mpim:history permissions.
     */
    public class FindMessages : SlackApiGet<JsonChannelHistory>
    {
        private string _latest, _oldest, _channelId;
        private bool _inclusive, _unreads;
        private int _count;
        private ChannelType _channelType;

        private void Initialize(string channelId, string latest, string oldest, bool inclusive, bool unreads, int count, ChannelType channelType)
        {
            _channelId = channelId;
            _latest = latest;
            _oldest = oldest;
            _inclusive = inclusive;
            _unreads = unreads;
            _count = count;
            _channelType = channelType;
        }

        /**
         * @param token - The Bot, Workspace or User token of the app.
         * @param channel - The ID of the channel holding the message.
         * @param latest - The most recent message timestamp to be found.
         * @param oldest - The oldest message timestamp to be found.
         * @param inclusive - Signifies whether the latest and oldest timestamps are included in the allowed time period or not.
         * @param channelType - Signifies whether the message is in a public, private, direct or multi-party channel.
         */
        public FindMessages(string token, string channel, string latest, string oldest, bool inclusive, ChannelType channelType) : base(token)
        {
            Initialize(channel, latest, oldest, true, false, 100, channelType);
        }

        /**
         * Constructor that allows for the option to show the unread count of the found message.
         * 
         * @param token - The Bot, Workspace or User token of the app.
         * @param channel - The ID of the channel holding the message.
         * @param latest - The most recent message timestamp to be found.
         * @param oldest - The oldest message timestamp to be found.
         * @param channelType - Signifies whether the message is in a public, private, direct or multi-party channel.
         * @param inclusive - Signifies whether the latest and oldest timestamps are included in the allowed time period or not.
         * @param unreads - Signifies whether the unread count is shown or not.
         * @param count - The max number of messages to return.
         */

        public FindMessages(string token, string channel, string latest, string oldest, bool inclusive, ChannelType channelType, bool unreads, int count) : base(token)
        {
            Initialize(channel, latest, oldest, true, unreads, count, channelType);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.CALLBACK_ID, _count.ToString());
            request.Add(DicKeys.INCLUSIVE, _inclusive.ToString());
            request.Add(DicKeys.LATEST, _latest);
            request.Add(DicKeys.OLDEST, _oldest);
            request.Add(DicKeys.UNREADS, _unreads.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            switch (_channelType)
            {
                case ChannelType.DIRECT:
                    return ApiUrls.GET_DIRECT_CHANNEL_HISTORY;
                case ChannelType.MULTI_DIRECT:
                    return ApiUrls.GET_MULTI_DIRECT_CHANNEL_HISTORY;
                case ChannelType.PRIVATE:
                    return ApiUrls.GET_PRIVATE_CHANNEL_HISTORY;
                case ChannelType.PUBLIC:
                    return ApiUrls.GET_PUBLIC_CHANNEL_HISTORY;
            }
            return "";
        }
    }
}
