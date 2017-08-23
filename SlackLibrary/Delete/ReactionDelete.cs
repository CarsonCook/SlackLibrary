using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Class that removes a reaction from an item in Slack. The item can be a file, message or file comment.
     * If it is a message, the channel of the message and the message timestamp are needed as the parent ID and item ID.
     * If it is a file comment, the file ID and comment ID are needed.
     * There is a special constructor for removing from a file, as no parent ID is needed, just a file ID.
     * 
     * Requires the reactions:write permission.
     */
    public class ReactionDelete : SlackApiDelete
    {
        private string _itemIdentifier, _name, _parentIdentifier;
        private ItemType _itemType;

        /**
         * Constructor for removing a reaction from a message or file comment.
         * 
         * @param token - The token of the bot.
         * @param name - The reaction name without the colons. For example, thumbs_up or +1
         * @param parentIdentifier - The channel/file ID for a message/file comment.
         * @param itemIdentifier - The timestamp/file comment ID for a message/file comment.
         * @param itemType - The ItemType specifying what the reaction is being removed from. Should be either MESSAGE or FILE_COMMENT.
         */
        public ReactionDelete(string token, string name, string parentIdentifier, string itemIdentifier, ItemType itemType) : base(token)
        {
            _name = name;
            _itemIdentifier = itemIdentifier;
            _parentIdentifier = parentIdentifier;
            _itemType = itemType;
        }

        /**
         * Constructor for removing a reaction from a file.
         * 
         * @param token - The token of the bot.
         * @param name - The reaction name without the colons. For example, thumbs_up or +1
         * @param fileId - The ID of the file that the reaction is to be removed from.
         */
        public ReactionDelete(string token, string name, string fileId) : base(token)
        {
            _name = name;
            _parentIdentifier = fileId;
            _itemType = ItemType.FILE;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.NAME, _name);
            request.Add(GetParentKey(), _parentIdentifier);

            //add the channel/file comment ID for a message/file comment, if it is one of those
            if (_itemType == ItemType.MESSAGE)
            {
                request.Add(DicKeys.TIMESTAMP, _itemIdentifier);
            }
            else if (_itemType == ItemType.FILE_COMMENT)
            {
                request.Add(DicKeys.FILE_COMMENT, _itemIdentifier);
            }
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.DELETE_REACTION;
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
                case ItemType.FILE:
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE;
                case ItemType.MESSAGE:
                    return DicKeys.CHANNEL;
            }
            return ""; //Bad ItemType, let API call fail
        }
    }
}