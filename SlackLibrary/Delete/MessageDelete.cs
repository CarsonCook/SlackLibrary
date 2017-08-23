using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Class that will delete a message in Slack. Can delete either a file comment or a regular message in any
     * channel. A message requires the channel ID to be the parent identifier, a file comment requires the 
     * file ID to be the parent ID.
     * 
     * Requires the chat:write:bot and files:write:user permissions.
     */
    public class MessageDelete : SlackApiDelete
    {
        private string _itemIdentifier, _parentId;
        private ItemType _itemType;

        /**
         * @param token - The token of the bot.
         * @param parentIdentifier - The channel/file ID for a message/file comment.
         * @param itemIdentifier - The timestamp/file comment ID for a message/file comment.
         * @param itemType - The ItemType specifying what the reaction is being removed from. Should be either MESSAGE or FILE_COMMENT.
         */
        public MessageDelete(string token, string parentIdentifier, string identifier, ItemType itemType) : base(token)
        {
            _itemIdentifier = identifier;
            _parentId = parentIdentifier;
            _itemType = itemType;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(GetParentKey(), _parentId);

            //set identifier key according to type, if not comment or message, don't call
            //as this class is meant for only messages or file comments
            if (_itemType == ItemType.MESSAGE || _itemType == ItemType.FILE_COMMENT)
            {
                string identifierKey = _itemType == ItemType.MESSAGE ? DicKeys.TS : DicKeys.ID;
                request.Add(identifierKey, _itemIdentifier);
            }
            return request;
        }

        protected override string GetApiUrl()
        {
            return _itemType == ItemType.MESSAGE ? ApiUrls.DELETE_MESSAGE : ApiUrls.DELETE_FILE_COMMENT;
        }

        /**
         * Method that gets the proper key fro a given item.
         * 
         * @return string - The string key.
         */
        private string GetParentKey()
        {
            switch (_itemType)
            {
                case ItemType.MESSAGE:
                    return DicKeys.CHANNEL;
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE;
            }
            return ""; //bad ItemType, let API call fail
        }
    }
}