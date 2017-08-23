using SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamLogsJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Team
{
    /**
     * Class used to retrieve the logs of the Slack team. Currently only has login logs.
     * 
     * Requires the admin permission, and for the team to be paying for Slack.
     */
    public class GetTeamAccessLogs : SlackApiGet<JsonAccessLogsResponse>
    {
        private string _beforeTs = "";
        private int _count = 100, _page = 1; //default values

        /**
         * Constructor for a basic retrieval of all logs.
         * 
         * @param token - The app Workspace or User token.
         */
        public GetTeamAccessLogs(string token) : base(token)
        {
        }

        /**
         * Constructor for a basic retrieval of all logs made before (inclusive) a given timestamp.
         * 
         * @param beforeTs - The timestamp that filters out logs made after it.
         */
        public GetTeamAccessLogs(string token, string beforeTs) : base(token)
        {
            _beforeTs = beforeTs;
        }

        /**
         * Constructor for a formatted retrieval of all logs made after (inclusive) a given timestamp.
         */
        public GetTeamAccessLogs(string token, string beforeTs, int count, int page) : base(token)
        {
            _beforeTs = beforeTs;
            _count = count;
            _page = page;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.BEFORE, _beforeTs);
            request.Add(DicKeys.COUNT, _count.ToString());
            request.Add(DicKeys.PAGE, _page.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_TEAM_ACCESS_LOGS;
        }
    }
}