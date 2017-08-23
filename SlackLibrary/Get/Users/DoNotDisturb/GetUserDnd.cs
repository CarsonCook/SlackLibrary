using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Users.DoNotDisturb
{
    /**
     * Class that retrieves a given user's do not disturb (dnd) status.
     * 
     * Requires the dnd:read permission.
     */
    public class GetUserDnd : SlackApiGet<JsonUserDndResponse>
    {
        private string _userId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Bot or User token of the app.
         * @param userId - The ID of the user DND status is retrieved.
         */
        public GetUserDnd(string token, string userId) : base(token)
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
            return ApiUrls.GET_USER_DND;
        }
    }
}