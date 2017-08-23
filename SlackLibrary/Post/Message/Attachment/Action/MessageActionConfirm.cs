using SlackITSupport.SlackLibrary.Message;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Attachment.Action
{
    /**
     * Class that represents a confirmation pop up for when a user invokes a Slack message action.
     */
    public class MessageActionConfirm : IMessageComponent
    {
        private string _title, _text, _ok_text, _dismiss_text;

        /**
         * @param title - The title of the pop up.
         * @param text - The text of the pop up.
         * @param ok_text - The text for the "confirm" button.
         * @param dismiss_text - The text for the "cancel" button.
         */
        public MessageActionConfirm(string title, string text, string ok_text, string dismiss_text)
        {
            _title = title;
            _text = text;
            _ok_text = ok_text;
            _dismiss_text = dismiss_text;
        }

        public Dictionary<string, dynamic> Build()
        {
            Dictionary<string, dynamic> confirm = new Dictionary<string, dynamic>
            {
                {DicKeys.TITLE,_title },
                {DicKeys.TEXT,_text },
                {DicKeys.OK_TEXT, _ok_text },
                {DicKeys.DISMISS_TEXT,_dismiss_text }
            };
            return confirm;
        }
    }
}