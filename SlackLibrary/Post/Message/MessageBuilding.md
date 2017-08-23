## Message Building

The Message folder holds classes related to sending messages in Slack, using a custom app (the message post classes). [Here](https://api.slack.com/docs/messages) is the documentation on how to build a message in Slack.

### IMessageComponent

This is an interface that forces all parts of a message (attachments, actions, etc.) to have a Build() method. It will create the Dictionary representing a JSON request for that message component.

It is public because when creating messages responding to slash commands, the Build() method needs to be used by client code.

### MessageAttachment

This class is used to hold information about a message's attachment, and then create that attachment. It implements the IMessageComponent interface so it has a Build() method available.

### MessageAction

This class is used to hold information about an action to be used in a message attachment, and then create that action.

At the very least, the text for the action must be passed using a constructor, with options for the name, value and type of action as well. The name defaults to whatever the text is, value defaults to an empty string and the type defaults to button.

### MessageActionConfirm

This class is used to hold information about the confirmation of an action, and then create that confirmation. For a specific button or menu selection, when the user clicks it, a popup window can be shown with an OK or NOT OK button. Clicking OK will fire the action and whatever callback logic applies. Click NOT OK will do nothing.

The title and text for the popup, along with both buttons' text and the text upon dismissal all must be provided.

### MessageActionOption

This class is used to hold information about the options of an action menu, and then create that menu. It is possible to have a menu instead of a button by having the type as select instead of button. This class holds one item within that menu; the MessageAction class takes a list of options to build the full menu.

The text and value must be given to the option, with optionally a description.
