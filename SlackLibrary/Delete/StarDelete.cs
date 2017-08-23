using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Class used to remove a star from a channel, file, message or file comment in Slack.
     * 
     * Requires the stars:write permission.
     */
    public class StarDelete : SlackApiDelete
    {
        private string _itemId, _parentId;
        private ItemType _itemType;

        /**
         * Constructor for un-starring a channel or file.
         * 
         * @param token - The app Bot, Workspace or User token.
         * @param id - The ID of the channel or file that will be un-starred.
         * @param itemType - Signifies if a channel or file is being un-starred.
         *                 Should be either CHANNEL or FILE.
         */
        public StarDelete(string token, string id, ItemType itemType) : base(token)
        {
            _parentId = id;
            _itemType = itemType;
        }

        /**
         * Constructor for un-starring a message or file comment.
         * 
         * @param parentId - The ID of the channel/file that holds the message/file comment.
         * @param itemId - The ID of the message or file comment that will be unstarred.
         * @param itemType - Signifies if a message or file comment is being un-starred.
         *                  Should be either MESSAGE or FILE_COMMENT.
         */
        public StarDelete(string token, string parentId, string itemId, ItemType itemType) : base(token)
        {
            _itemType = itemType;
            _itemId = itemId;
            _parentId = parentId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(GetItemTypeKey(), _parentId);
            request.Add(GetSecondKey(), _itemId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.DELETE_STAR;
        }

        /**
         * Method that gets the Dictionary request key for the ItemType.
         * 
         * @return string - The string key.
         */
        private string GetItemTypeKey()
        {
            switch (_itemType)
            {
                case ItemType.MESSAGE:
                case ItemType.CHANNEL:
                    return DicKeys.CHANNEL;
                case ItemType.FILE_COMMENT:
                case ItemType.FILE:
                    return DicKeys.FILE;
            }
            return ""; //bad ItemType passed in, let API call fail
        }

        /**
         * Method that gets the request Dictionary key for un-starring a message or file comment.
         * 
         * @return string - The request Dictionary key.
         */
        private string GetSecondKey()
        {
            switch (_itemType)
            {
                case ItemType.MESSAGE:
                    return DicKeys.TIMESTAMP;
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE_COMMENT;
            }
            return ""; //don't need a second piece of data, it will be ignored
        }
    }
}