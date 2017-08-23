using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Class that will delete a reminder from Slack.
     * 
     * Requires the reminders:write permission.
     */
    public class ReminderDelete : SlackApiDelete
    {
        private string _reminderId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param reminderId - The ID of the reminder to be deleted.
         */
        public ReminderDelete(string token, string reminderId) : base(token)
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
            return ApiUrls.DELETE_REMINDER;
        }
    }
}