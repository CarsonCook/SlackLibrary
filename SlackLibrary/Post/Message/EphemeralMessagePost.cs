using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.Post.Attachment;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Message
{
    /**
     * Class that is used to post a message to a given channel only visible to the given user.
     * 
     * This is called an Ephemeral message. These messages are only sent when the given user is
     * active and a member of the given channel. They also do not persist in any way.
     * 
     * Requires the chat:write:bot or chat:write:user permissions, depending if the message is being
     * post as the bot or as a user.
     */
    public class EphemeralMessagePost : SlackApiPost
    {
        private string _channelId, _text, _userId;
        private bool _asUser, _linkNames;
        private List<Dictionary<string, dynamic>> _attachments = new List<Dictionary<string, dynamic>>();

        /**
         * Method used to set instance variables to avoid constructor repitition.
         * 
         * @param channelId - The ID of the channel the message will be posted to.
         * @param asUser - Signifies if the message will be posted as the authenticated user or as the bot user.
         * @param linkNames - Signifies if the channel names and user names will be linked.
         * @param attachments - The attachments to add to the message.
         */
        private void Initialize(string text, string userId, string channelId, bool asUser, bool linkNames, List<MessageAttachment> attachments)
        {
            _userId = userId;
            _text = text;
            _channelId = channelId;
            _asUser = asUser;
            _linkNames = linkNames;
            if (attachments != null)
            {
                foreach (MessageAttachment attachment in attachments)
                {
                    _attachments.Add(attachment?.Build());
                }
            }
        }

        /**
         * Constructor for a basic message.
         * 
         * @param token - The app Bot, Workspace or User token.
         * @param text - The text of the message.
         * @param userId - The ID of the user that will receive the message.
         */
        public EphemeralMessagePost(string token, string text, string userId, string channelId) : base(token)
        {
            Initialize(text, userId, channelId, false, true, null);
        }

        /**
         * Constructor for a basic message, but with attachments.
         */
        public EphemeralMessagePost(string token, string text, string userId, string channelId, List<MessageAttachment> attachments) : base(token)
        {
            Initialize(text, userId, channelId, false, true, attachments);
        }

        /**
         * Constructor for a message with the optional parameters used.
         */
        public EphemeralMessagePost(string token, string text, string userId, string channelId, bool asUser, bool linkNames) : base(token)
        {
            Initialize(text, userId, channelId, asUser, linkNames, null);
        }

        /**
         * Constructor for a message with the optional parameters used, and with attachments.
         */
        public EphemeralMessagePost(string token, string text, string userId, string channelId, List<MessageAttachment> attachments, bool asUser, bool linkNames) : base(token)
        {
            Initialize(text, userId, channelId, asUser, linkNames, attachments);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.TEXT, _text);
            request.Add(DicKeys.USER, _userId);
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.AS_USER, _asUser.ToString());
            request.Add(DicKeys.LINK_NAMES, _linkNames.ToString());
            request.Add(DicKeys.ATTACHMENTS, JsonConvert.SerializeObject(_attachments));
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.POST_EPHEMERAL_MESSAGE;
        }
    }
}