using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post
{
    /**
     * Class used to star an item. Items include files, file comments, channels and messages.
     * 
     * Requires the stars:write permission.
     */
    public class StarItem : SlackApiPost
    {
        private string _parentId, _itemId;
        private ItemType _itemType;

        /**
         * Constructor for starring a channel or file.
         * 
         * @param token - The app Bot, Workspace or User token.
         * @param itemId - The to be starred channel/file ID.
         * @param itemType - Signifies what type of item is being starred. Should be either FILE or CHANNEL.
         */
        public StarItem(string token, string itemId, ItemType itemType) : base(token)
        {
            _parentId = itemId;
            _itemId = "";
            _itemType = itemType;
        }

        /**
         * Constructor for starring a message or file comment.
         * 
         * @param parentId - The ID of the channel (for a message) or file (for a file comment) that holds the item to be starred.
         * @param childId - The message/file comment ID to be starred.
         * @param itemType - Signifies what type of item is being starred. Should be either MESSAGE or FILE_COMMENT.
         */
        public StarItem(string token, string parentId, string childId, ItemType itemType) : base(token)
        {
            _parentId = parentId;
            _itemId = childId;
            _itemType = itemType;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(GetParentKey(), _parentId);
            if (_itemId != "")
            {
                request.Add(GetItemKey(), _itemId);
            }
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.ADD_STAR;
        }

        /**
         * Method that gets the proper key fro a given item.
         * 
         * @return string - The string key.
         */
        private string GetItemKey()
        {
            switch (_itemType)
            {
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE_COMMENT;
                case ItemType.MESSAGE:
                    return DicKeys.TIMESTAMP;
            }
            return ""; //either bad ItemType or it is a CHANNEL/FILE and doesn't have a second piece of data
        }

        /**
         * Method that gets the proper key for a given item.
         * 
         * @return string - The string key.
         */
        private string GetParentKey()
        {
            switch (_itemType)
            {
                case ItemType.MESSAGE:
                case ItemType.CHANNEL:
                    return DicKeys.CHANNEL;
                case ItemType.FILE:
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE;
            }
            return ""; //bad ItemType, let call fail
        }
    }
}