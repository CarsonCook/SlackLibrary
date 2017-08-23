using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post.Message
{
    /**
     * Class used to add a comment to a given file.
     * 
     * Requires the files:write:user permission.
     */
    public class FileCommentPost : SlackApiPost
    {
        private string _text, _fileId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param text - The text of the file comment.
         * @param fileId - The ID of the file where the comment will be added.
         */
        public FileCommentPost(string token, string text, string fileId) : base(token)
        {
            _text = text;
            _fileId = fileId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.FILE, _fileId);
            request.Add(DicKeys.COMMENT, _text);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.FILE_COMMENT_POST;
        }
    }
}