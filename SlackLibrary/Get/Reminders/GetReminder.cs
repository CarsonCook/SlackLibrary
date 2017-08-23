using SlackITSupport.SlackLibrary.JsonParsing.ReminderJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Reminders
{
    /**
     * Class that gets a specific reminder from the app's Slack team.
     * 
     * Requires the reminders:read permission.
     */
    public class GetReminder : SlackApiGet<JsonReminderGet>
    {
        private string _reminderId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The User token of the Workspace app.
         * @param reminderId - The ID of the reminder being retrieved.
         */
        public GetReminder(string token, string reminderId) : base(token)
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
            return ApiUrls.GET_REMINDER;
        }
    }
}