using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.File.URL
{
    /**
     * Class that disables public sharing for a file.
     * 
     * Requires teh files:write:user permission.
     */
    public class ShareFilePrivately : SlackApiPost
    {
        private string _fileId;

        /**
         * @param token - The app Workspace or User token.
         * @param fileId - The ID of the file to revoke public sharing for.
         */
        public ShareFilePrivately(string token, string fileId) : base(token)
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
            return ApiUrls.PROTECT_FILE_URL;
        }
    }
}