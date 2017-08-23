using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.ListJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    /**
     * Class that retrieves the items pinned to a given channel.
     * 
     * Requires the pins:read permission.
     */
    public class GetPinned : SlackApiGet<JsonListResponse>
    {
        private string _channelId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channelId - The ID of the channel for which the pinned items are being retrieved.
         */
        public GetPinned(string token, string channelId) : base(token)
        {
            _channelId = channelId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_CHANNEL_PINNED;
        }
    }
}