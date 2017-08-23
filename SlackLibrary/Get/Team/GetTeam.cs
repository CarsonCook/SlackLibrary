using SlackITSupport.SlackLibrary.JsonParsing.TeamJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Team
{
    /**
     * Class that gets information about the app's Slack team.
     * 
     * Requires the team:read permission. 
     */
    public class GetTeam : SlackApiGet<JsonTeamGet>
    {

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used. There is also no ID needed so a blank string is used to show that.
         * 
         * @param token - The Workspace, Bot or User token of the Workspace app.
         */
        public GetTeam(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_TEAM;
        }
    }
}