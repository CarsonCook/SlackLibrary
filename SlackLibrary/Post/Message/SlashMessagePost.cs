using SlackITSupport.SlackLibrary.Message;
using SlackITSupport.SlackLibrary.Post.Attachment;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post
{
    /**
     * Class that represents a Slack message responding to an invoked custom slash command.
     */
    public class SlashMessagePost : IMessageComponent
    {
        private string _text, _thread_ts, _response_type;
        private List<Dictionary<string, dynamic>> _attachments = new List<Dictionary<string, dynamic>>();
        private bool _replace_original;

        /**
         * Method used to set instance variables to avoid repetition in constructors.
         * 
         * @param text - The text of the message.
         * @param thread_ts - Parent message this will reply to, empty string if it is not to be replied to.
         * @param response_type - How the message appears - visible to all users in the channel or only the slash command invoker.
         * @param attachments - A list of message attachments.
         * @param replace_original - Signifies if this message replaces the original message.
         */
        private void Initialize(string text, string thread_ts, string response_type, List<MessageAttachment> attachments, bool replace_original)
        {
            _text = text;
            _thread_ts = thread_ts;
            _response_type = response_type;
            if (attachments != null)
            {
                foreach (MessageAttachment attachment in attachments)
                {
                    _attachments.Add(attachment.Build()); //create the JSON for attachments as they are defined here
                }
            }
            _replace_original = replace_original;
        }

        public SlashMessagePost(string text, List<MessageAttachment> attachments)
        {
            Initialize(text, "", Constants.NO_VISIBLE_TO_ALL, attachments, false);
        }

        public SlashMessagePost(string text)
        {
            Initialize(text, "", Constants.NO_VISIBLE_TO_ALL, null, false);
        }

        public SlashMessagePost(string text, string thread_ts, string response_type, List<MessageAttachment> attachments, bool replace_original)
        {
            Initialize(text, thread_ts, response_type, attachments, replace_original);
        }

        public SlashMessagePost(string text, string response_type, List<MessageAttachment> attachments, bool replace_original)
        {
            Initialize(text, "", response_type, attachments, replace_original);
        }

        public Dictionary<string, dynamic> Build()
        {
            Dictionary<string, dynamic> message = new Dictionary<string, dynamic>
            {
                {DicKeys.TEXT,_text },
                {DicKeys.THREAD_TS,_thread_ts },
                {DicKeys.RESPONSE_TYPE,_response_type },
                {DicKeys.REPLACE_ORIGINAL,_replace_original },
                {DicKeys.ATTACHMENTS,_attachments.ToArray() } //attachments is array - Slack API
            };
            return message;
        }
    }
}