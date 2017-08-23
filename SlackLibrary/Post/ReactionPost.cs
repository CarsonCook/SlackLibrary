using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post
{
    /**
     * Class that will add a reaction to an item.
     * 
     * Requires the reactions:write permission.
     */
    public class ReactionPost : SlackApiPost
    {
        private string _item_identifier, _parentId, _reactionName;
        private ItemType _itemType;

        /**
         * Constructor to be used for adding a reaction to a message or file comment.
         * 
         * @param token - The app's Bot, Workspace or User token.
         * @param reactionName - The string name of the reaction to be added.
         * @param parentIdentifier - The ID of the channel/file for the message/file comment
         * @param itemIdentifier - The ID of the message/file comment.
         * @param itemType - Signifies if the item is a message or file comment.
         */
        public ReactionPost(string token, string reactionName, string parentIdentifier, string itemIdentifier, ItemType itemType) : base(token)
        {
            _item_identifier = itemIdentifier;
            _parentId = parentIdentifier;
            _reactionName = reactionName;
            _itemType = itemType;
        }

        /**
         * Constructor to be used for adding a reaction to a file.
         * 
         * @param token - The app's Bot, Workspace or User token.
         * @param reactionName - The string name of the reaction to be added.
         * @param fileId - The ID of the file to receive the reaction.
         */
        public ReactionPost(string token, string reactionName, string fileId) : base(token)
        {
            _reactionName = reactionName;
            _parentId = fileId;
            _itemType = ItemType.FILE;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.NAME, _reactionName);
            request.Add(GetParentKey(), _parentId);
            request.Add(GetItemKey(), _item_identifier);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.POST_REACTION;
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
                case ItemType.MESSAGE:
                    return DicKeys.TIMESTAMP;
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE_COMMENT;
            }
            return ""; //no item key to return
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
                case ItemType.FILE:
                case ItemType.FILE_COMMENT:
                    return DicKeys.FILE;
                case ItemType.MESSAGE:
                    return DicKeys.CHANNEL;
            }
            return null; //given bad ItemType value, let call fail
        }
    }
}