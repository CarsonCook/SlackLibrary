using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.User.Status
{
    /**
     * Class used to end the authenticated users' snooze.
     * 
     * Requires the dnd:write permission.
     */
    public class UserEndSnooze : SlackApiPost
    {
        /**
         * @param token - The app User token.
         */
        public UserEndSnooze(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.END_SNOOZE;
        }
    }
}