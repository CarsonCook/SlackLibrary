using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.UserGroup
{
    /**
     * Class used to enabled a previously disabled usergroup.
     * 
     * Requires the usergroups:write permission and a paid Slack team.
     */
    public class EnableUsergroup : SlackApiPost
    {
        private string _usergroupId;

        /**
         * @param token - The app Workspace or User token.
         */
        public EnableUsergroup(string token, string usergroupId) : base(token)
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
            return ApiUrls.ENABLE_USERGROUP;
        }
    }
}