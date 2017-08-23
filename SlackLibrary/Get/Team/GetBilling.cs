using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.BillingJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Team
{
    /**
     * Class used to retrieve which users can be billed by Slack.
     * 
     * Requires the admin permission.
     */
    public class GetBilling : SlackApiGet<JsonBillingResponse>
    {
        private string _userId = "";

        /**
         * Constructor for retrieving all users' billing information.
         * 
         * @param token - The app Workspace or User token.
         */
        public GetBilling(string token) : base(token)
        {
        }

        /**
         * Constructor for retrieving a given user's billing information.
         * 
         * @param userId - The ID of the user that billing information is retrieved for.
         */
        public GetBilling(string token, string userId) : base(token)
        {
            _userId = userId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_BILLING_INFO;
        }
    }
}