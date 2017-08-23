using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Users
{
    /**
     * Class that retrives the profile information of a user in the app's Slack team.
     * 
     * Requires the users.profile:read permission.
     */
    public class GetUserProfile : SlackApiGet<JsonGetUserProfile>
    {
        private string _userId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace or User token of the Workspace app.
         * @param userId - The ID of the user who's profile is being retrieved.
         */
        public GetUserProfile(string token, string userId) : base(token)
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
            return ApiUrls.GET_USER_PROFILE;
        }
    }
}