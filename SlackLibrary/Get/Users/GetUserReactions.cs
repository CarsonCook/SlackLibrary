using SlackITSupport.SlackLibrary.JsonParsing.ListJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Users
{
    /**
     * Class used to retrieve all of the items a user has reacted to, and what those reactions were.
     * 
     * Requires the reactions:read permission.
     */
    public class GetUserReactions : SlackApiGet<JsonListResponse>
    {
        private int _count, _page;
        private bool _full;
        private string _userId;

        /**
         * Method used to set the intance variables to avoid constructor repitition.
         * 
         * @param count - The number of items to return per page.
         * @param page - The page number of results to return.
         * @param full - Signifies if the full reaction list is to be returned.
         */
        private void Initialize(string userId, int count, int page, bool full)
        {
            _userId = userId;
            _count = count;
            _page = page;
            _full = full;
        }

        /**
         * Constructor used to have optional parameters be logical defaults.
         * 
         * @param token - The app's Bot, Workspace or User token.
         * @param userId - The ID of the user for which reaction items are being retrieved.
         */
        public GetUserReactions(string token, string userId) : base(token)
        {
            Initialize(userId, 100, 1, true);
        }

        public GetUserReactions(string token, string userId, int count, int page, bool full) : base(token)
        {
            Initialize(userId, count, page, full);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.USER, _userId);
            request.Add(DicKeys.COUNT, _count.ToString());
            request.Add(DicKeys.PAGE, _page.ToString());
            request.Add(DicKeys.FULL, _full.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_ALL_USER_REACTED_TO;
        }
    }
}