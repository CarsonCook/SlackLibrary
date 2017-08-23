using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.File
{
    /**
     * Class used to edit a given file comment on a given file.
     * 
     * Requires the files:write:user permission.
     */
    public class EditFileComment : SlackApiPost
    {
        private string _text, _fileId, _commentId;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param text - The new text of the comment.
         * @param fileId - The ID of the file holding the comment to be edited.
         * @param commentId - The ID of the comment to edit.
         */
        public EditFileComment(string token, string text, string fileId, string commentId) : base(token)
        {
            _text = text;
            _fileId = fileId;
            _commentId = commentId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.COMMENT, _text);
            request.Add(DicKeys.FILE, _fileId);
            request.Add(DicKeys.ID, _commentId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.EDIT_FILE_COMMENT;
        }
    }
}