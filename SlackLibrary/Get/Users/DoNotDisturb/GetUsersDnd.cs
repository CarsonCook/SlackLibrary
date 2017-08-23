using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Users.DoNotDisturb
{
    /**
     * Class used to get multiple user do not disturb settings.
     * 
     * Requiesr the dnd:read permission.
     */
    public class GetUsersDnd : SlackApiGet<JsonUsersDndResponse>
    {
        private string _userIds;

        /**
         * Constructor for getting all user DND settings.
         * 
         * @param token - The app Bot or User token.
         */
        public GetUsersDnd(string token) : base(token)
        {
        }

        /**
         * Constructor for getting DND settings for the specified users.
         * 
         * @param userIds - A List of the IDs of users to retrieve DND settings for.
         */
        public GetUsersDnd(string token, List<string> userIds) : base(token)
        {
            _userIds = string.Join(",", userIds);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USER, _userIds);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_TEAM_DND;
        }
    }
}