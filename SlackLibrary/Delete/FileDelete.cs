using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Class that will delete a given file from Slack.
     * 
     * Requires the files:write:user permission.
     */
    public class FileDelete : SlackApiDelete
    {
        private string _fileId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param fileId - The ID of the file to be deleted.
         */
        public FileDelete(string token, string fileId) : base(token)
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
            return ApiUrls.DELETE_FILE;
        }
    }
}