using SlackITSupport.SlackLibrary.JsonParsing.ListJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Users
{
    /**
     * Class used to retrieve everything starred by the authenticated user.
     * 
     * Requires the stars:read permission.
     */
    public class GetUserStarred : SlackApiGet<JsonListPagingResponse>
    {
        private int _count, _page;

        /**
         * Method used to set instance variables in order to avoid repitition in constructors.
         * 
         * @param count - The number of items to return per page.
         * @param page - The page number of results to return.
         */
        private void Initialize(int count, int page)
        {
            _count = count;
            _page = page;
        }

        /**
         * Constructor that uses the default values for count and page.
         * 
         * @param token - The app Workspace or User token.
         */
        public GetUserStarred(string token) : base(token)
        {
            Initialize(100, 1);
        }

        /**
         * Constructor for customizing how the results are returned.
         */
        public GetUserStarred(string token, int count, int page) : base(token)
        {
            Initialize(count, page);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.COUNT, _count.ToString());
            request.Add(DicKeys.PAGE, _page.ToString());
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_ALL_USER_STARRED;
        }
    }
}