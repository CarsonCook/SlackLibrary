using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.FileJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.File
{
    public enum FileType { ALL, FILE_POSTS, SNIPPETS, IMAGES, GOOGLE_DOCS, ZIPS, PDFS };

    /**
     * Class used to retrieve multiple files. They can be filtered by time posted, type, channel they were posted to and user that posted them.
     * Note that when reading the result from Slack, the URI can have a maximum of 2083 characters. Often searching for all files
     * within a team, unless they are of a type that is uncommon, will go over this limit and result in a 500 service error.
     * 
     * Requires the files:read permission.
     */
    public class GetFiles : SlackApiGet<JsonFilesResponse>
    {
        private FileType _fileType;
        private string _channelId, _tsFrom, _tsTo, _userId;
        private int _count, _page;

        /**
         * Method that sets instance variables in order to avoid constructor repitition.
         * 
         * @param channelId - The ID of the channel to filter files by. Empty if unused.
         * @param count - The number of items to return per page.
         * @param page - The page number of results to return.
         * @param tsFrom - The timestamp to filter files posted after (inclusive). Empty if unused.
         * @param tsTo - The timestamp to filter files posted before (inclusive). Empty if unused.
         * @param fileType - Signifies what kind of kile is being looked for.
         * @param userId - The ID of the user to filter files by. Empty if unused.
         */
        private void Initialize(string channelId, int count, int page, string tsFrom, string tsTo, FileType fileType, string userId)
        {
            _fileType = fileType;
            _channelId = channelId;
            _tsFrom = tsFrom;
            _tsTo = tsTo;
            _userId = userId;
            _count = count;
            _page = page;
        }

        /**
         * Constructor for search for all files of a certain type.
         */
        public GetFiles(string token, FileType fileType) : base(token)
        {
            Initialize("", 100, 1, "", "", fileType, "");
        }

        /**
         * Constructor for search for files in a certain channel.
         */
        public GetFiles(string token, string channelId, FileType fileType) : base(token)
        {
            Initialize(channelId, 100, 1, "", "", fileType, "");
        }

        /**
         * Constructor for search for files posted by a certain user.
         */
        public GetFiles(string token, FileType fileType, string userId) : base(token)
        {
            Initialize("", 100, 1, "", "", fileType, userId);
        }

        /**
         * Constructor for search for files posted between certain times.
         */
        public GetFiles(string token, string tsFrom, string tsTo, FileType fileType) : base(token)
        {
            Initialize("", 100, 1, tsFrom, tsTo, fileType, "");
        }

        /**
         * Constructor for setting all optional parameters in the file retrieval.
         */
        public GetFiles(string token, string channelId, int count, int page, string tsFrom, string tsTo, FileType fileType, string userId) : base(token)
        {
            Initialize(channelId, count, page, tsFrom, tsTo, fileType, userId);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.COUNT, _count.ToString());
            request.Add(DicKeys.PAGE, _page.ToString());
            request.Add(DicKeys.TS_FROM, _tsFrom);
            request.Add(DicKeys.TS_TO, _tsTo);
            request.Add(DicKeys.TYPES, GetFileTypeString());
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_FILES;
        }

        private string GetFileTypeString()
        {
            switch (_fileType)
            {
                case FileType.ALL:
                    return DicKeys.ALL;
                case FileType.GOOGLE_DOCS:
                    return DicKeys.GDOCS;
                case FileType.SNIPPETS:
                    return DicKeys.SNIPPETS;
                case FileType.FILE_POSTS:
                    return DicKeys.SPACES;
                case FileType.IMAGES:
                    return DicKeys.IMAGES;
                case FileType.ZIPS:
                    return DicKeys.ZIPS;
                case FileType.PDFS:
                    return DicKeys.PDFS;
            }
            return ""; //bad FileType passed in
        }
    }
}