using System.Collections.Generic;
using System.Threading.Tasks;
using SlackITSupport.SlackLibrary.JsonParsing;
using SlackITSupport.SlackLibrary.SlackConstants;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;

namespace SlackITSupport.SlackLibrary.Events
{
    /**
     * Class that retrieves a list of reactions for a given item.
     * 
     * Requires the reactions:read permission.
     */
    public class GetItemReactions : SlackApiGet<JsonReaction>
    {
        private string _item_identifier, _parentId;
        private ItemType _itemType;

        /**
         * The ChannelType is arbitrary and does not matter. The parent class requires it be passed into it's constructor,
         * but it is not used.
         * 
         * Constructor used to get reactions for a message or file comment.
         * 
         * @param token - The Workspace or User token of the Workspace app.
         * @param parent_identifier - The ID of the channel/file for holding the message/file comment.
         * @param item_identifier - The ID of the message/file comment that reactions are being retrieved for.
         * @param itemType - Signifies whether reactions are being retrieved for a message or a file comment.
         */
        public GetItemReactions(string token, string parent_identifier, string item_identifier, ItemType itemType) : base(token)
        {
            _parentId = parent_identifier;
            _item_identifier = item_identifier;
            _itemType = itemType;
        }

        /**
         * The ChannelType is arbitrary and does not matter. The parent class requires it be passed into it's constructor,
         * but it is not used.
         * 
         * Constructor used to get reactions for a file
         * 
         * @param token - The Workspace or User token of the Workspace app.
         * @param fileId - The ID of the file reactions are being retrieved for.
         */
        public GetItemReactions(string token, string fileId) : base(token)
        {
            _parentId = fileId;
            _itemType = ItemType.FILE;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(GetParentKey(), _parentId);
            request.Add(GetItemKey(), _item_identifier);
            return request;
        }

        /**
         * Method that finds if the instance item has at least one reaction.
         * 
         * @return Task<bool> bool representing if the item has at least one reaction.
         */
        public async Task<bool> HasAnyReaction()
        {
            return await Get() != null;
        }

        /**
         * Method that finds if the instance item has the given reaction.
         * 
         * @param reactionName - The string name of the reaction being looked for.
         * @return bool - Signifies if the item has the given reaction.
         */
        public async Task<bool> HasReaction(string reactionName)
        {
            JsonReaction reactionsResponse = await Get();
            if (reactionsResponse == null || reactionsResponse.Message.Reactions == null)
            {
                return false;
            }

            JsonMessageReaction[] reactions = reactionsResponse.Message.Reactions;
            foreach (JsonMessageReaction reaction in reactions)
            {
                if (reaction.Name == reactionName)
                {
                    return true;
                }
            }
            return false;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_REACTIONS;
        }

        /**
         * Method that gets the key for the item in the request Dictionary.
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
            return ""; //bad ItemType
        }

        /**
         * Method that gets the key for the parent in the request Dictionary.
         * 
         * @return string - The string key.
         */
        private string GetParentKey()
        {
            switch (_itemType)
            {
                case ItemType.FILE_COMMENT:
                case ItemType.FILE:
                    return DicKeys.FILE;
                case ItemType.MESSAGE:
                    return DicKeys.CHANNEL;
            }
            return ""; //bad ItemType passed in, let API call fail
        }
    }
}