using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.UserGroup
{
    /**
     * Class used to disable an existing usergroup.
     * 
     * Requires the usergroups:write permission and a paid Slack team.
     */
    public class DisableUsergroup : SlackApiPost
    {
        private string _usergroupId;

        /**
         * @param token - The app Workspace or User token.
         */
        public DisableUsergroup(string token, string usergroupId) : base(token)
        {
            _usergroupId = usergroupId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USERGROUP, _usergroupId);
            request.Add(DicKeys.INCLUDE_COUNT, false.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.DISABLE_USERGROUP;
        }
    }
}