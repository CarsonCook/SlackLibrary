using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Events.Users
{
    /**
     * Class that retrieves information about one user in the app's Slack team.
     * 
     * Requires the users:read permission.
     */
    public class GetUser : SlackApiGet<JsonUser>
    {
        private string _userId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace or User token of the Workspace app.
         * @param user_id - The ID of the user to be retrieved.
         */
        public GetUser(string token, string user_id) : base(token)
        {
            _userId = user_id;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_USER_INFO;
        }
    }
}