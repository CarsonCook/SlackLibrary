using SlackITSupport.SlackLibrary.JsonParsing.UserGroupsJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.UserGroup
{
    /**
     * Class that retrieves a list of users within a given user group.
     * 
     * Requires the usergroups:read permission and a paid Slack team.
     */
    public class GetUsersInGroup : SlackApiGet<JsonGetUsersInGroup>
    {
        private string _usergroup;
        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace or User token of the Workspace app. 
         */
        public GetUsersInGroup(string token, string usergroup) : base(token)
        {
            _usergroup = usergroup;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USERGROUP, _usergroup);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_USERGROUP_USERS;
        }
    }
}