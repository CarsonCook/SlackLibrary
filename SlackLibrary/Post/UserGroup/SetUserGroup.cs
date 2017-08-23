using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.UserGroup
{
    /**
     * Class used to set the properties of a given usergroup.
     * 
     * Requires the usergroups:write permission and a paid Slack team.
     */
    public class SetUserGroup : SlackApiPost
    {
        private string _usergroupId, _description, _handle, _name, _channels;
        private bool _includeCount;

        /**
         * Method used to set the instance variables in order to avoid constructor repitition.
         * 
         * @param usergroupId - The ID of the usergroup for which properties will be set.
         * @param description - The description of the usergroup.
         * @param handle - A mention handle for the usergroup.
         * @param name - The name of the usergroup.
         * @param channels - An array of the channels the usergroup will use.
         * @param includeCount - Signifies if the number of users in the usergroup will be included.
         */
        private void Initialize(string usergroupId, string description, string handle, string name, string[] channels, bool includeCount)
        {
            _usergroupId = usergroupId;
            _description = description;
            _handle = handle;
            _name = name;
            _channels = string.Join(",", channels);
            _includeCount = includeCount;
        }

        /**
         * Constructor for setting only the description and name.
         * 
         * @param token - The app Workspace or User token.
         */
        public SetUserGroup(string token, string usergroupId, string description, string name) : base(token)
        {
            Initialize(usergroupId, description, "", name, null, true);
        }

        /**
         * Constructor for setting all usergroup properties.
         */
        public SetUserGroup(string token, string usergroupId, string description, string handle, string name, string[] channels, bool includeCount) : base(token)
        {
            Initialize(usergroupId, description, handle, name, channels, includeCount);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USERGROUP, _usergroupId);
            request.Add(DicKeys.CHANNELS, _channels);
            request.Add(DicKeys.DESCRIPTION, _description);
            request.Add(DicKeys.HANDLE, _handle);
            request.Add(DicKeys.INCLUDE_COUNT, _includeCount.ToString());
            request.Add(DicKeys.NAME, _name);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.SET_USERGROUP;
        }
    }
}