using SlackITSupport.SlackLibrary.JsonParsing.FileJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.File
{
    /**
     * Class that gets a specific file from the app's Slack team.
     * 
     * Documentation from Slack shows options for number of items per page and pages to return, however upon testing
     * this seems to not be needed as only one file is ever retrieved at once.
     * 
     * Requires the files:read permission. 
     */
    public class GetFile : SlackApiGet<JsonFileGet>
    {
        private string _fileId;

        /**
         * The ItemType and ChannelType are arbitrary and do not matter. The parent class requires these be passed into it's constructor,
         * but those pieces of information are not used.
         * 
         * @param token - The Workspace, Bot or User token of the Workspace app.
         * @param fileId - The ID of the file being retrieved.
         */
        public GetFile(string token, string fileId) : base(token)
        {
            _fileId = fileId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.FILE, _fileId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_FILE;
        }
    }
}