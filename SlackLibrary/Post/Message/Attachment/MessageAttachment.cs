using SlackITSupport.SlackLibrary.Message;
using SlackITSupport.SlackLibrary.Post.Attachment.Action;
using SlackITSupport.SlackLibrary.SlackConstants;
using System;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Attachment
{
    /**
     * Class that represents a Slack message attachment. 
     */
    public class MessageAttachment : IMessageComponent
    {
        private string _fallback, _color, _pretext, _author, _iconLink, _title, _titleLink, _text, _callback, _imageURL, _thumbURL, _footer, _footerIcon;
        private Dictionary<string, string> _field; //TO DO make this a class like _action
        private List<Dictionary<string, dynamic>> _actions = new List<Dictionary<string, dynamic>>();
        private double _timestamp;

        /**
         * Method used to set instance variables to avoid repetition in constructors.
         * 
         * @param fallback - The text to use if the attachment cannot be loaded.
         * @param color - A hex color code to signify the importance of the attachment.
         * @param pretext - The text appearing in the message before the attachment.
         * @param author - The name of the message creator.
         * @param iconLink - The URL for an icon used in the attachment.
         * @param title - The title of the attachment.
         * @param titleLink - The URL for the title of the attachment.
         * @param text - The attachment main text.
         * @param callback - The URL called when an action is done.
         * @param imageURL - The URL of an image used in the attachment.
         * @param thumbURL - The URL of the thumbnail picture.
         * @param footerIcon - The URL of the icon used in the footer.
         * @param field - A table of text in the attachment.
         * @param actions - The actions (usually buttons) in the attachment.
         * @param timestamp - The timestamp of something referenced by the attachment, for example a news article.
         */
        private void Initialize(string fallback, string color, string pretext, string author, string iconLink, string title, string titleLink, string text, string callback,
            string imageURL, string thumbURL, string footer, string footerIcon, Dictionary<string, string> field, List<MessageAction> actions, double timestamp)
        {
            _fallback = fallback;
            _color = color;
            _pretext = pretext;
            _author = author;
            _iconLink = iconLink;
            _title = title;
            _titleLink = titleLink;
            _text = text;
            _callback = callback;
            _imageURL = imageURL;
            _thumbURL = thumbURL;
            _footer = footer;
            _footerIcon = footerIcon;
            _field = field;
            if (actions != null)
            {
                foreach (MessageAction action in actions)
                {
                    _actions.Add(action.Build()); //create the JSON for the action as they are defined here
                }
            }
            _timestamp = timestamp;
        }

        //constructors for commonly used attributes
        public MessageAttachment(string title, string text)
        {
            Initialize("", "", "", "", "", title, "", text, "button", "", "", "", "", null, null, (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public MessageAttachment(string title, string text, List<MessageAction> actions)
        {
            Initialize("", "", "", "", "", title, "", text, "button", "", "", "", "", null, actions, (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public MessageAttachment(string title, string text, string callback)
        {
            Initialize("", "", "", "", "", title, "", text, callback, "", "", "", "", null, null, (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public MessageAttachment(string title, string text, string callback, List<MessageAction> actions)
        {
            Initialize("", "", "", "", "", title, "", text, callback, "", "", "", "", null, actions, (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public Dictionary<string, dynamic> Build()
        {
            Dictionary<string, dynamic> attachment = new Dictionary<string, dynamic>
            {
                {DicKeys.TITLE,_title },
                {DicKeys.TEXT,_text },
                {DicKeys.ACTIONS,_actions.ToArray() }, //actions is array - Slack API
                {DicKeys.CALLBACK_ID,_callback }
            };
            return attachment;
        }
    }
}