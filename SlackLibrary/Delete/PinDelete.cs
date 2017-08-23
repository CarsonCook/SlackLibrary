using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Class used to un-pin a file, message or file comment from a channel in Slack.
     * 
     * Requires the pins:write permission.
     */
    public class PinDelete : SlackApiDelete
    {
        private string _itemId, _channelId;
        private ItemType _itemType;

        /**
         * Constructor for un-starring a channel or file.
         * 
         * @param token - The app Bot, Workspace or User token.
         * @param channelId - The ID of the channel holding the item to be un-pinned.
         * @param itemType - Signifies if the item being unpinned is a file, file comment or message.
         *                  Should be either FILE, FILE_COMMENT or MESSAGE
         */
        public PinDelete(string token, string channelId, string itemId, ItemType itemType) : base(token)
        {
            _itemId = itemId;
            _channelId = channelId;
            _itemType = itemType;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(GetItemKey(), _itemId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.DELETE_PIN;
        }
        
        /**
         * Method that gets the request Dictionary key for un-starring a message or file comment.
         * 
         * @return string - The request Dictionary key.
         */
        private string GetItemKey()
        {
            switch (_itemType)
            {
                case ItemType.MESSAGE:
                    return DicKeys.TIMESTAMP;
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE_COMMENT;
                case ItemType.FILE:
                    return DicKeys.FILE;
            }
            return ""; //don't need a second piece of data, it will be ignored
        }
    }
}