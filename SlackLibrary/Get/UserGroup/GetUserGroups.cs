using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.UserGroupsJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.UserGroup
{
    /**
     * Class that retrieves a list of information of each user group in the app's Slack team.
     * 
     * Requires the usergroups:read permission and a paid Slack team.
     */
    public class GetUserGroups : SlackApiGet<JsonUserGroupsResponse>
    {
        private bool _includeCount, _includeUsers;

        /**
         * Handles setting instance variables to avoid repetition in the constructors.
         */
        private void Initialize(bool includeCount, bool includeUsers)
        {
            _includeCount = includeCount;
            _includeUsers = includeUsers;
        }

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace or User token of the Workspace app. 
         */
        public GetUserGroups(string token) : base(token)
        {
            Initialize(true, true);
        }

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * Constructor to configure optional the inclusion of certain pieces of information in the response.
         * 
         * @param token - The Workspace or User token of the Workspace app.
         * @param includeCount - Signifies whether the number of users in each user group is retrieved.
         * @param includeUsers - Signifies whether or not the users in each user group are retrieved.
         */
        public GetUserGroups(string token, bool includeCount, bool includeUsers) : base(token)
        {
            Initialize(includeCount, includeUsers);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.INCLUDE_COUNT, _includeCount.ToString());
            request.Add(DicKeys.INCLUDE_USERS, _includeUsers.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_USERGROUPS;
        }
    }
}
 