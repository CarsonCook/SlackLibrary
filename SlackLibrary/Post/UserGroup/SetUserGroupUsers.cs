using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.UserGroup
{
    /**
     * Class used to set the given users to be in a given usergroup.
     * 
     * Requires the usergroups:write permission and a paid Slack team.
     */
    public class SetUserGroupUsers : SlackApiPost
    {
        private string _usergroupId, _userIds;

        /**
         * @param token - The app Workspace or User token.
         */
        public SetUserGroupUsers(string token, string usergroupId, string[] userIds) : base(token)
        {
            _usergroupId = usergroupId;
            _userIds = string.Join(",", userIds);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USERGROUP, _usergroupId);
            request.Add(DicKeys.USERS, _userIds);
            request.Add(DicKeys.INCLUDE_COUNT, false.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.SET_USERGROUPS_USERS;
        }
    }
}