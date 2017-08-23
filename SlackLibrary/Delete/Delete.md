# Delete

This folder holds classes that remove items from Slack, for example un-pinning a message or deleting a file comment.

## StarDelete

This class un-stars a file, channel, message or file comment. Requires the stars:write permission.

[API documentation](https://api.slack.com/methods/stars.remove).

## ReminderDelete

This class deletes a reminder. It can be on-going or completed. Requires the reminders:write permission.

[API documentation](https://api.slack.com/methods/reminders.delete).

## ReactionDelete

This class removes a given reaction from a file, file comment or message. Requires the reactions:write permission.

[API documentation](https://api.slack.com/methods/reactions.remove).

## ProfilePicDelete

This class deletes the authenticated app user's profile picture. Requires the users.profile:write permission.

[API documentation](https://api.slack.com/methods/users.deletePhoto).

## PinDelete

This class un-pins a file, file comment or message from a channel. Requires the pins:write permission.

[API documentation](https://api.slack.com/methods/pins.remove).

## MessageDelete

This class deletes either a file comment or message. Requires the chat:write:bot (for messages) and files:write:user permissions (for file comments).

[Message API Documentation](https://api.slack.com/methods/chat.delete), [file comment API documentation](https://slack.com/api/files.comments.delete).

## FileDelete

This class deletes a file. Requires the files:write:user permission.

[API documentation](https://api.slack.com/methods/files.delete).
