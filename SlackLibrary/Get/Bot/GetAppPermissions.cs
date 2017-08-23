using SlackITSupport.SlackLibrary.JsonParsing.AppJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Bot
{
    /**
     * Class that retrieves the permission information of a Workspace Slack application.
     */
    public class GetAppPermissions : SlackApiGet<JsonApp>
    {
        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace token of the Workspace app.
         */
        public GetAppPermissions(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_APP_PERMISSIONS;
        }
    }
}