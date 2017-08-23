using SlackITSupport.SlackLibrary.JsonParsing.ReminderJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Reminders
{
    /**
     * Class that gets all reminders from the app's Slack team.
     * 
     * Requires the reminders:read permission.
     */
    public class GetRemindersForUser : SlackApiGet<JsonRemindersGet>
    {
        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The User token of the Workspace app.
         */
        public GetRemindersForUser(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_ALL_REMINDERS;
        }
    }
}