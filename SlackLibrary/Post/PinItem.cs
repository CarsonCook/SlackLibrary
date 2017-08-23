using System.Collections.Generic;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Post
{
    /**
     * Class that pins a file, file comment or message to the given channel.
     * 
     * Requires the pins:write permission.
     */
    public class PinItem : SlackApiPost
    {
        private string _channelId, _itemId;
        private ItemType _itemType;

        /**
         * @param token - The app Bot, Workspace or User token.
         * @param channelId - The ID of the channel the item will be pinned to.
         * @param itemType - Signifies the type of item being pinned. Should be FILE, FILE_COMMENT or MESSAGE.
         */
        public PinItem(string token, string channelId, string itemId, ItemType itemType) : base(token)
        {
            _channelId = channelId;
            _itemId = itemId;
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
            return ApiUrls.PIN_ITEM;
        }

        /**
         * Method that gets the proper key for a given item.
         * 
         * @return string - The string key.
         */
        private string GetItemKey()
        {
            switch (_itemType)
            {
                case ItemType.FILE:
                    return DicKeys.FILE;
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE_COMMENT;
                case ItemType.MESSAGE:
                    return DicKeys.TIMESTAMP;
            }
            return ""; //bad ItemType, allow call to fail
        }
    }
}