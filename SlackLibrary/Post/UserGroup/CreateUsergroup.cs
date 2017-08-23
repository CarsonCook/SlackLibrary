using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.UserGroup
{
    /**
     * Class used to create a usergroup.
     * 
     * Requires the usergroups:write permission and the team being a paid team.
     */
    public class CreateUsergroup : SlackApiPost
    {
        private string _groupName, _channelIds, _description, _handle;
        private bool _includeCount;

        /**
         * Method used to set instance variables in order to avoid repitition in constructors.
         * 
         * @param groupName - The name of the new usergroup.
         * @param channelIds - An array of channel IDs the usergroup uses.
         * @param description - The usergroup description.
         * @param handle - The mention handle for the usergroup.
         * @param includeCount - Signifies if the number of users in the group will be shown.
         */
        private void Initialize(string groupName, string[] channelIds, string description, string handle, bool includeCount)
        {
            _groupName = groupName;
            if (channelIds != null)
            {
                _channelIds = string.Join(",", channelIds);
            }
            else
            {
                _channelIds = "";
            }
            _description = description;
            _handle = handle;
            _includeCount = includeCount;
        }

        /**
         * Constructor for creating a simple usergroup with no data.
         * 
         * @param token - The app Workspace or User token.
         */
        public CreateUsergroup(string token, string groupName) : base(token)
        {
            Initialize(groupName, null, "", "", true);
        }

        /**
         * Constructor for creating a simple usergroup with all options configurable.
         */
        public CreateUsergroup(string token, string groupName, string[] channelIds, string description, string handle, bool includeCount) : base(token)
        {
            Initialize(groupName, channelIds, description, handle, includeCount);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.NAME, _groupName);
            request.Add(DicKeys.CHANNELS, _channelIds);
            request.Add(DicKeys.DESCRIPTION, _description);
            request.Add(DicKeys.HANDLE, _handle);
            request.Add(DicKeys.INCLUDE_COUNT, _includeCount.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.CREATE_USERGROUP;
        }
    }
}