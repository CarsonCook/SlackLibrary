using SlackITSupport.SlackLibrary.Message;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Attachment.Action
{
    /**
     * Class that represents a button in an action of a Slack message attachment
     */
    public class MessageActionOption : IMessageComponent
    {
        private string _text, _value, _description;

        /**
         * Method used to set instance variables to avoid repetition in constructors.
         * 
         * @param text - The text in the button.
         * @param value - A string used to ID the button.
         * @param description - A description of the button.
         */
        private void Initialize(string text, string value, string description)
        {
            _text = text;
            _value = value;
            _description = description;
        }

        public MessageActionOption(string text, string value, string description)
        {
            Initialize(text, value, description);
        }

        public MessageActionOption(string text, string value)
        {
            Initialize(text, value, "");
        }

        public Dictionary<string, dynamic> Build()
        {
            Dictionary<string, dynamic> option = new Dictionary<string, dynamic>
            {
                {DicKeys.TEXT,_text },
                {DicKeys.VALUE,_value },
                {DicKeys.DESCRIPTION,_description }
            };
            return option;
        }
    }
}