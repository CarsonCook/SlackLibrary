using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Users
{
    /**
     * Class that retrieves all of the users in the app's Slack team.
     * 
     * Requires the users:read permission.
     */
    public class GetAllUsers : SlackApiGet<JsonUserList>
    {
        private int _limit;
        private bool _presence;
        
        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Bot, Workspace, User token of the Workspace app.
         * @param limit - the max number of users to return.
         * @param presence - Signifies whether to retrieve the user's presence data
         */
        public GetAllUsers(string token, int limit, bool presence) : base(token)
        {
            _limit = limit;
            _presence = presence;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.LIMIT, _limit.ToString());
            request.Add(DicKeys.PRESENCE, _presence.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_ALL_USERS;
        }
    }
}