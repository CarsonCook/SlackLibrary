using SlackITSupport.SlackLibrary.Message;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Post.Attachment.Action
{
    /**
     * Class that represents an action in a Slack message attachment.
     */
    public class MessageAction : IMessageComponent
    {
        private string _name, _text, _value, _type;
        private Dictionary<string,dynamic> _confirm;
        private List<Dictionary<string, dynamic>> _options=new List<Dictionary<string, dynamic>>();

        /**
         * Method that sets instance variables to avoid repetition in constructors.
         * 
         * @param name - The name of the message action.
         * @param text - The text in the message action.
         * @param value - A way to ID the message action.
         * @param type - The type of action, usually button.
         * @param confirm - The MessageActionConfirmation for this action, a pop up confirming the user's actions.
         * @param options - A list of MessageActionOptions holding the options for the action. Usually buttons.
         */
        private void Initialize(string name, string text, string value, string type, MessageActionConfirm confirm, List<MessageActionOption> options)
        {
            _name = name;
            _text = text;
            _value = value;
            _type = type;
            _confirm = confirm?.Build();
            if (options != null)
            {
                foreach (MessageActionOption option in options)
                {
                    _options.Add(option.Build());
                }
            }
        }

        public MessageAction(string name, string text, string value, string type)
        {
            Initialize(name, text, value, type, null,null);
        }

        public MessageAction(string name, string text, MessageActionConfirm confirm)
        {
            Initialize(name, text, "", Constants.BUTTON, confirm,null);
        }

        public MessageAction(string name, string text)
        {
            Initialize(name, text, "", Constants.BUTTON, null, null);
        }

        public MessageAction(string text)
        {
            Initialize(text, text, "", Constants.BUTTON, null, null);
        }

        public MessageAction(string text, MessageActionConfirm confirm)
        {
            Initialize(text, text, "", Constants.BUTTON, confirm, null);
        }

        public MessageAction(string name, string text, string value, string type, MessageActionConfirm confirm, List<MessageActionOption> options)
        {
            Initialize(name, text, value, type, confirm, options);
        }

        public Dictionary<string, dynamic> Build()
        {
            Dictionary<string, dynamic> actions = new Dictionary<string, dynamic>
            {
                {DicKeys.NAME,_name},
                {DicKeys.TEXT,_text},
                {DicKeys.TYPE,_type},
                {DicKeys.VALUE,_value},
                {DicKeys.OPTIONS,_options }
            };
            //if add null confirm then a default confirm is still added so this prevents that
            if (_confirm != null)
            {
                actions.Add(DicKeys.CONFIRM, _confirm);
            }
            return actions;
        }
    }
}