using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.User.Status
{
    /**
     * Class used to set the authenticated user's status to active, but only for the Slack messaging servers, not other users.
     * 
     * Requires the users:write permission.
     */
    public class SetUserActive : SlackApiPost
    {
        /**
         * @param token - The app Bot or User token.
         */
        public SetUserActive(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.SET_USER_ACTIVE;
        }
    }
}