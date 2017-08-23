using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;
using SlackITSupport.SlackLibrary.JsonParsing.SearchJson;

namespace SlackITSupport.SlackLibrary.Search
{
    public enum SearchType { ALL, FILES, MESSAGES };
    public enum SortDirection { ASC, DESC };
    public enum SortType { TS, SCORE };

    /**
     * Class that searches Slack using the built-in Slack search ability.
     * This is not getting a history of messages and using word relation to return matches.
     * This class can search for files, messages or both.
     * 
     * Requires the search:read permission.
     * 
     */
    public class SlackSearch : SlackApiGet<JsonSearch>
    {
        private string _sort, _sort_dir, _query;
        private int _count, _page;
        private bool _highlight;
        private SearchType _search_type;

        private void Initialize(string query, string sort, string sort_dir, int count, int page, bool highlight, SearchType searchType)
        {
            _query = query;
            _sort = sort;
            _sort_dir = sort_dir;
            _count = count;
            _page = page;
            _highlight = highlight;
            _search_type = searchType;
        }

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace or User token of the app.
         * @param query - The equivalent of what a human user would type in the Slack search bar.
         * @param searchType - Signifies whether the search is for files, messages or both.
         */
        public SlackSearch(string token, string query, SearchType searchType) : base(token)
        {
            Initialize(query, Constants.SORT_SCORE, Constants.SORT_DIR_DESC, 20, 1, true, searchType);
        }

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * This constructor is used to provide extra options to the search result.
         * 
         * @param token - The Workspace or User token of the app.
         * @param query - The equivalent of what a human user would type in the Slack search bar.
         * @param searchType - Signifies whether the search is for files, messages or both.
         * @param sort - Signifies how the results are sorted - by timestamp or score.
         * @param sort_dir - Signifies whether the results are sorted ascending or descending.
         * @param count - The max number of items to return per page.
         * @param page - The max number of pages to return.
         * @param highlight - Signifies whether the matching query terms are highlighted or not.
         */
        public SlackSearch(string token, string query, SearchType searchType, SortType sort, SortDirection sort_dir, int count, int page, bool highlight) : base(token)
        {
            Initialize(query, sort == SortType.TS ? Constants.SORT_TIMESTAMP : Constants.SORT_SCORE,
                sort_dir == SortDirection.ASC ? Constants.SORT_DIR_ASC : Constants.SORT_DIR_DESC, count, page, highlight, searchType);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            //build the query string for the values
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.QUERY, _query);
            request.Add(DicKeys.COUNT, _count.ToString());
            request.Add(DicKeys.HIGHLIGHT, _highlight.ToString());
            request.Add(DicKeys.PAGE, _page.ToString());
            request.Add(DicKeys.SORT, _sort);
            request.Add(DicKeys.SORT_DIR, _sort_dir);
            return request;
        }

        protected override string GetApiUrl()
        {
            switch (_search_type)
            {
                case SearchType.ALL:
                    return ApiUrls.SEARCH_ITEMS;
                case SearchType.FILES:
                    return ApiUrls.SEARCH_FILES;
                case SearchType.MESSAGES:
                    return ApiUrls.SEARCH_MESSAGES;
            }
            return ""; //won't get here with current SearchType options
        }
    }
}