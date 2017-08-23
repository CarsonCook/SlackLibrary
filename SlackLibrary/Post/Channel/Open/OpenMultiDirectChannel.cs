using SlackITSupport.SlackLibrary.SlackConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackITSupport.SlackLibrary.Post.Channel.Open
{
    /**
     * Class used to open a direct channel between the authenticated user and 
     * other given users.
     * All this does is add that multi direct channel onto your sidebar.
     * 
     * Requires the mpim:write permission. 
     */
    public class OpenMultiDirectChannel : SlackApiPost
    {
        private string _userIds;

        /**
         * @param token - The app Bot or User token.
         * @param userIds - The ID of the users to open a multi direct channel with.
         */
        public OpenMultiDirectChannel(string token, string[] userIds) : base(token)
        {
            _userIds = string.Join(",",userIds);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USERS, _userIds);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.OPEN_MULTI_DIRECT_CHANNEL;
        }
    }
}