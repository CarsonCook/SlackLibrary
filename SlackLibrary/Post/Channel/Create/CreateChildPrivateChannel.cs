using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Channel.Create
{
    /**
     * Class used to make a child channel from a given private channel.
     * This method renames the given private channel and archives it. A new
     * private channel is made using the old name of the given channel and adds
     * all members from that channel.
     * 
     * Requires the groups:write permission.
     */
    public class CreateChildPrivateChannel : SlackApiPost
    {
        private string _channelId;

        /**
         * @param token - The app Workspace or User token.
         * @param channelId - The ID of the private channel to make a child for.
         */
        public CreateChildPrivateChannel(string token, string channelId) : base(token)
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
            return ApiUrls.CREATE_CHILD_PRIVATE_CHANNEL;
        }
    }
}