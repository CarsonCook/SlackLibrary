using SlackITSupport.SlackLibrary.SlackConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackITSupport.SlackLibrary.Post.Channel.Open
{
    /**
     * Class used to open a direct channel between the authenticated user and 
     * another given user.
     * All this does is add that user onto your sidebar.
     * 
     * Requires the im:write permission.
     */
    public class OpenDirectChannel : SlackApiPost
    {
        private string _userId;

        /**
         * @param token - The app Bot or User token.
         * @param userId - The ID of the user to open a direct channel with.
         */
        public OpenDirectChannel(string token, string userId) : base(token)
        {
            _userId = userId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.OPEN_DIRECT_CHANNEL;
        }
    }
}