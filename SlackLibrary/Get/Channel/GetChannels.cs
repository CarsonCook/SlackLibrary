using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    /**
     * Class that retrieves information about a channel. Can be public, private, direct or multi direct.
     * 
     * Requires the channels:read, groups:read, im:read and mpim:read permissions.
     */
    public class GetChannels : SlackApiGet<JsonGetChannels>
    {
        private ChannelType _channeltype;
        private bool _excludeArchived, _excludeMembers;

        /**
         * Method that sets instance variables to avoid repetition in constructors.
         * 
         * @param excludeArchived - Signifies if archived channels will be included in the response.
         * @param excludeMembers - Signifies if members will be included in the response.
         * @param channelType - Signifies if the channels being listed are public, private, direct or multi direct.
         */
        private void Initialize(bool excludeArchived, bool excludeMembers, ChannelType channelType)
        {
            _channeltype = channelType;
            _excludeArchived = excludeArchived;
            _excludeMembers = excludeMembers;
        }

        /**
         * @param token - The app Bot, Workspace or User token.
         */
        public GetChannels(string token, ChannelType channelType) : base(token)
        {
            Initialize(false, false, channelType);
        }

        /**
         * Constructor for optional parameters that affect the response.
         */
        public GetChannels(string token, bool excludeArchived, bool excludeMembers, ChannelType channelType) : base(token)
        {
            Initialize(excludeArchived, excludeMembers, channelType);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.EXCLUDE_ARCHIVED, _excludeArchived.ToString());
            request.Add(DicKeys.EXCLUDE_MEMBERS, _excludeMembers.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            switch (_channeltype)
            {
                case ChannelType.DIRECT:
                    return ApiUrls.GET_ALL_CHANNELS_DIRECT;
                case ChannelType.PRIVATE:
                    return ApiUrls.GET_ALL_CHANNELS_PRIVATE;
                case ChannelType.PUBLIC:
                    return ApiUrls.GET_ALL_CHANNELS_PUBLIC;
                case ChannelType.MULTI_DIRECT:
                    return ApiUrls.GET_ALL_CHANNELS_MULTI_DIRECT;
            }
            return "";
        }
    }
}