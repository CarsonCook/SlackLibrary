using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Reminder
{
    /**
     * Class that will create a reminder for the given user. The reminder can be a single instance or repeating.
     * 
     * Requires the reminders:write permission.
     */
    public class CreateReminder : SlackApiPost
    {
        private string _userId, _reminderTime, _reminderText;

        /**
         * @param token - The app User token.
         * @param reminderTime - The time for the reminder to be made. If the reminder is within 24 hours, the number of seconds can be used.
         *                       If the reminder is within 5 years, a Unix timestamp can be used. A natural language description can also
         *                       be used, for example 'in 15 minutes' or 'every Thursday'.
         * @param reminderText - The content of the reminder.
         * @param userId - The ID of the user that will receive the reminder.
         */
        public CreateReminder(string token, string reminderTime, string reminderText, string userId) : base(token)
        {
            _reminderTime = reminderTime;
            _reminderText = reminderText;
            _userId = userId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.TIME, _reminderTime);
            request.Add(DicKeys.TEXT, _reminderText);
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.CREATE_REMINDER;
        }
    }
}