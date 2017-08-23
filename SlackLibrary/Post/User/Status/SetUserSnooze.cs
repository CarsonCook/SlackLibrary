using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.User.Status
{
    /**
     * Class used to set the authenticated user's Do Not Disturb status to snoozed.
     * 
     * Requires the dnd:write permission.
     */
    public class SetUserSnooze : SlackApiPost
    {
        private int _numMinutes;

        /**
         * @param token - The app User token.
         * @param numMinutes - The number of minutes from now for the user to be snoozed.
         */
        public SetUserSnooze(string token, int numMinutes) : base(token)
        {
            _numMinutes = numMinutes;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.NUM_MINUTES, _numMinutes.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.SET_SNOOZE;
        }
    }
}