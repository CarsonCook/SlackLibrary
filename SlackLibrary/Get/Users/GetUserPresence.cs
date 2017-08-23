using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Users
{
    /**
     * Class that retrives the presence status of a user in the app's Slack team.
     * 
     * Requires the users:read permission.
     */
    public class GetUserPresence : SlackApiGet<JsonUserPresence>
    {
        private string _userId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace or User token of the Workspace app.
         * @param userId - The ID of the user to retrieve presence for.
         */
        public GetUserPresence(string token, string userId) : base(token)
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
            return ApiUrls.GET_PRESENCE;
        }
    }
}