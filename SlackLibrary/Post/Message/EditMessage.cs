using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.Post.Attachment;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Message
{
    /**
     * Class used to edit a given message in a given channel.
     * 
     * Requires the chat:write:bot (asUser false) and chat:write:user (asUser true) permissions.
     */
    public class EditMessage : SlackApiPost
    {
        private string _channelId, _text, _ts;
        private bool _asUser, _linknames;
        private List<Dictionary<string, dynamic>> _attachments = new List<Dictionary<string, dynamic>>();

        /**
         * Method that sets instance variables to avoid repeition throughout the many constructors.
         * 
         * @param channelId - The ID of the channel holding the message to be edited.
         * @param text - The new text of the message.
         * @param ts - The timestamp of the message to be edited
         * @param asUser - Signifies if the message is posted as the bot user (false) or the authenticated user (true).
         * @param linkNames - Signifies if channel and user names will be linked when 
         * @param attachments - A list of the Slack attachments for the message.
         */
        private void Initialize(string channelId, string text, string ts, bool asUser, bool linkNames, List<MessageAttachment> attachments)
        {
            _channelId = channelId;
            _text = text;
            _ts = ts;
            _asUser = asUser;
            _linknames = linkNames;
            if (attachments != null)
            {
                foreach (MessageAttachment attachment in attachments)
                {
                    _attachments.Add(attachment?.Build());
                }
            }
        }

        /**
         * Constructor for a basic message edit.
         * 
         * @param token - The app Bot, Workspace or User token.
         */
        public EditMessage(string token, string channelId, string text, string ts) : base(token)
        {
            Initialize(channelId, text, ts, false, true, null);
        }

        /**
         * Constructor for a basic message edit with attachments.
         */
        public EditMessage(string token, string channelId, string text, string ts, List<MessageAttachment> attachments) : base(token)
        {
            Initialize(channelId, text, ts, false, true, attachments);
        }

        /**
         * Constructor for all options in the call.
         */
        public EditMessage(string token, string channelId, string text, string ts, bool asUser, bool linkNames, List<MessageAttachment> attachments) : base(token)
        {
            Initialize(channelId, text, ts, asUser, linkNames, attachments);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            request.Add(DicKeys.TS, _ts);
            request.Add(DicKeys.TEXT, _text);
            request.Add(DicKeys.AS_USER, _asUser.ToString());
            request.Add(DicKeys.ATTACHMENTS, JsonConvert.SerializeObject(_attachments));
            request.Add(DicKeys.LINK_NAMES, _linknames.ToString());
            //if names are to be linked, parse:full needs to be in call request
            if (_linknames)
            {
                request.Add(DicKeys.PARSE, Constants.FULL);
            }
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.UPDATE_MESSAGE;
        }
    }
}