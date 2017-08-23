using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.File.URL
{
    /**
     * Class that will enable a file to be shared publicly.
     * 
     * Requires the fiels:write:user permission.
     */
    public class ShareFilePublicly : SlackApiPost
    {
        private string _fileId;

        /**
         * @param token - The app Workspace or User token.
         * @apram fileId - The ID of the file to be shared publicly.
         */
        public ShareFilePublicly(string token, string fileId) : base(token)
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
            return ApiUrls.SHARE_FILE_URL;
        }
    }
}