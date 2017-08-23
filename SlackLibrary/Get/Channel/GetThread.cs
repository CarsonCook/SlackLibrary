using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    /**
     * Class that retrieves a thread from a given channel.
     * 
     * Requires the im:history (DIRECT), groups:history (PRIVATE), mpim:history (MULTI_DIRECT)
     * or channels:history permission (PUBLIC), depending on what type of channel holds the thread.
     */
    public class GetThread : SlackApiGet<JsonThreadResponse>
    {
        private ChannelType _channelType;
        private string _threadTs, _channelId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channelId - The ID of the channel holding the thread being retrieved.
         * @param threadTs - The timestamp of the thread being retrieved.
         * @param channelType - Signifies the type of channel the thread is being retrieved from.
         */
        public GetThread(string token, string channelId, string threadTs, ChannelType channelType) : base(token)
        {
            _threadTs = threadTs;
            _channelType = channelType;
            _channelId = channelId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.THREAD_TS, _threadTs);
            request.Add(DicKeys.CHANNEL, _channelId);
            return request;
        }

        protected override string GetApiUrl()
        {
            switch (_channelType)
            {
                case ChannelType.DIRECT:
                    return ApiUrls.GET_DIRECT_THREAD;
                case ChannelType.MULTI_DIRECT:
                    return ApiUrls.GET_MULTI_DIRECT_THREAD;
                case ChannelType.PRIVATE:
                    return ApiUrls.GET_PRIVATE_THREAD;
                case ChannelType.PUBLIC:
                    return ApiUrls.GET_PUBLIC_THREAD;
            }
            return ""; //bad ChannelType passed in
        }
    }
}