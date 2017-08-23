using Newtonsoft.Json;
using SlackITSupport.Models;
using SlackITSupport.SlackLibrary.JsonParsing.MessageJson;
using SlackITSupport.SlackLibrary.Post.Attachment;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post
{
    /**
     * Class that will post a message to Slack. It can post replies as well.
     * 
     * Requires the chat:write:bot (as_user false) or chat:write:user permission (as_user true).
     * 
     * Since there are many constructors, see the first one for the documentation on the parameters
     * sent to the parent class, and see Initialize() documentation for the rest of the parameters.
     */
    public class MessagePost : SlackApiPost
    {
        private string _channelId, _text, _username, _icon_url, _icon_emoji, _thread_ts;
        private bool _as_user, _reply_broadcast;
        private List<Dictionary<string, dynamic>> _attachments = new List<Dictionary<string, dynamic>>();

        /**
         * Method that sets instance variables to avoid repeition throughout the many constructors.
         * 
         * @param as_user - Signifies if the message is posted as the bot user (false) or the authenticated user (true).
         * @param attachments - A list of the Slack attachments for the message.
         * @param icon_url - URL for the icon used in the message.
         * @param icon_emoji - The name of the emoji used in the message.
         * @param reply_broadcast - Signifies if the message, if it is a reply, is also sent to the corresponding channel as a normal message.
         * @param thread_ts - If the message is to be a reply, the timestamp of the parent message.
         * @param username - If the message is being posted as the authenticated user, this username is set as that user.
         */
        private void Initialize(string channelId, string text, bool as_user, List<MessageAttachment> attachments, string icon_url,
            string icon_emoji, bool reply_broadcast, string thread_ts, string username)
        {
            _channelId = channelId;
            _text = text;
            _as_user = as_user;
            if (attachments != null)
            {
                foreach (MessageAttachment attachment in attachments)
                {
                    _attachments.Add(attachment?.Build());
                }
            }
            _icon_url = icon_url;
            _reply_broadcast = reply_broadcast;
            _thread_ts = thread_ts;
            _username = username;
            _icon_emoji = icon_emoji;
        }

        /**
         * @param token - The Bot, Workspace or User app token.
         * @param channel - The ID of the channel where the message is to be posted.
         * @param text - The text of the message to be posted.
         */
        public MessagePost(string token, string channel, string text, List<MessageAttachment> attachments) : base(token)
        {
            Initialize(channel, text, false, attachments, "", "", false, "", ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, string text) : base(token)
        {
            Initialize(channel, text, false, null, "", "", false, "", ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, string text, string thread_ts) : base(token)
        {
            Initialize(channel, text, false, null, "", "", false, thread_ts, ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, List<MessageAttachment> attachments) : base(token)
        {
            Initialize(channel, "", false, attachments, "", "", false, "", ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, string text, List<MessageAttachment> attachments, string thread_ts) : base(token)
        {
            Initialize(channel, text, false, attachments, "", "", true, thread_ts, ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, string text, string icon_url, string thread_ts) : base(token)
        {
            Initialize(channel, text, false, null, "", "", true, thread_ts, ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, List<MessageAttachment> attachments, string thread_ts) : base(token)
        {
            Initialize(channel, "", false, attachments, "", "", true, thread_ts, ControllerConstants.BOT_USERNAME);
        }

        public MessagePost(string token, string channel, string text, string username, List<MessageAttachment> attachments, string icon_url, string icon_emoji,
            bool reply_broadcast, string thread_ts) : base(token)
        {
            Initialize(channel, text, true, attachments, icon_url, icon_emoji, reply_broadcast, thread_ts, username);
        }

        public MessagePost(JsonMessage message) : base(message.Token)
        {
            if (message == null)
            {
                Initialize("", "", false, null, null, null, false, null, null);
            }
            else
            {
                List<MessageAttachment> attachments = new List<MessageAttachment>();
                foreach (JsonMessageAttachment att in message.Attachments)
                {
                    MessageAttachment attachment = new MessageAttachment(att.Title, att.Text);
                    attachments.Add(attachment);
                }
                Initialize(message.ThreadTs, message.Text, message.AsUser, attachments, message.IconUrl, message.IconEmoji, message.ReplyBroadcast, "", message.Username);
            }
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.TEXT, _text);
            request.Add(DicKeys.AS_USER, _as_user.ToString());
            request.Add(DicKeys.USERNAME, _username);
            request.Add(DicKeys.ATTACHMENTS, JsonConvert.SerializeObject(_attachments));
            request.Add(DicKeys.THREAD_TS, _thread_ts); //will make message a reply. DO NOT REPLY TO REPLIES - will destroy thread and lose messages

            //following only take effect when as_user false
            if (!_as_user)
            {
                request.Add(DicKeys.REPLY_BROADCAST, _reply_broadcast.ToString());
                request.Add(DicKeys.ICON_URL, _icon_url);
                request.Add(DicKeys.ICON_EMOJI, _icon_url);
            }
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.POST_MESSAGE;
        }
    }
}