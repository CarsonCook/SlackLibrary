using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.User.Status
{
    public enum PresenceStatus { AUTO, AWAY };

    /**
     * Class used to set the authenticated user's presence.
     * 
     * Requires the users:write permission.
     */
    public class SetUserPresence : SlackApiPost
    {
        private PresenceStatus _presence;

        /**
         * @param token - The app Bot or User token.
         * @param presenceStatus - Signifies if the user presence will be set to auto or away.
         */
        public SetUserPresence(string token, PresenceStatus presenceStatus) : base(token)
        {
            _presence = presenceStatus;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.PRESENCE, GetPresenceString());
            return request;
        }

        /**
         * Method to get the string value for the given presence status.
         * 
         * @return string - The value of the presence.
         */
        private string GetPresenceString()
        {
            return _presence == PresenceStatus.AUTO ? "auto" : "away";
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.SET_USER_PRESENCE;
        }
    }
}