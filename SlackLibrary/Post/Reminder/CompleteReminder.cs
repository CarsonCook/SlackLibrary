using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Reminder
{
    /**
     * Class that will mark a given reminder complete.
     * 
     * Requiers the reminders:write permission.
     */
    public class CompleteReminder : SlackApiPost
    {
        private string _reminderId;

        /**
         * @param token - The app User token.
         * @param reminderId - The ID of the reminder to be marked complete.
         */
        public CompleteReminder(string token, string reminderId) : base(token)
        {
            _reminderId = reminderId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.REMINDER, _reminderId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.COMPELTE_REMINDER;
        }
    }
}