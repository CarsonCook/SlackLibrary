using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.User.Status
{
    /**
     * Class used to end the authenticated user's Do Not Disturb immediately.
     * 
     * Requires the dnd:write permission.
     */
    public class UserEndDnd : SlackApiPost
    {
        /**
         * @param token - The app User token.
         */
        public UserEndDnd(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.END_DND;
        }
    }
}