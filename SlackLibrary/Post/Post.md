# Post

This folder holds the classes used to add something to Slack, for example sending a message or adding a reaction.

## StarItem

This class is used to star a file, file comment, channel or message in slack. Requires the stars:write permission.

[API documentation](https://api.slack.com/methods/stars.add).

## ReactionPost

This class is used to add a reaction to a message, file or file comment. Requires the reactions:write permission.

[API documentation](https://api.slack.com/methods/reactions.add).

## CreateReminder

This class is used to make a reminder, simulating the /remind command. Requires the reminders:write permission.

[API documentation](https://api.slack.com/methods/reminders.add).

## PinItem

This class is used to pin a file, file comment or message to a channel. Requires the pins:write permission.

[API documentation](https://api.slack.com/methods/pins.add).

## MessagePost

This class is used to post a message to a Slack channel. It can be a reply if the timestamp of the parent message to be is given. Requires the chat:write:bot permission (posting as a bot) and the chat:write:user (posting as the authenticated user) permissions.

[API documentation](https://api.slack.com/methods/chat.postMessage).

## FileCommentPost

This class is used to add a comment to a file. Requires the files:write:user permission.

[API documentation](https://api.slack.com/methods/files.comments.add).

## EphemeralMessagePost

This class is used to post a message that is only visible to the user receiving it. It also is non-persisting. Requires the chat:write:bot permission (posting as a bot) and the chat:write:user (posting as the authenticated user) permissions.

[API documentation](https://api.slack.com/methods/chat.postEphemeral).

## ShareFilePrivately

This class is used to limit a file from being shared outside of the Slack team. Requires the files:write:user permission.

[API documentation](https://api.slack.com/methods/files.revokePublicURL).

## ShareFilePublicly

This class is used to allow a file to be shared outside of the Slack team. Requires the files:write:user permission.

[API documentation](https://api.slack.com/methods/files.sharedPublicURL).

## EditFileComment

This class is used to edit a file comment. Requires the files:write:user permission. 

[API documentation](https://api.slack.com/methods/files.comments.edit).

## CompleteReminder

This class is used to mark a reminder as complete. Requires the reminders:write permission.

[API documentation](https://api.slack.com/methods/reminders.complete).

## UserEndDnd

This class is used to end the authenticated user's Do Not Disturb session immediately. Requires the dnd:write permission.

[API documentation](https://api.slack.com/methods/dnd.endDnd).

## UserEndSnooze

This class is used to end the authenticated user's snooze session immediately. Requires the dnd:write permission.

[API documentation](https://api.slack.com/methods/dnd.endSnooze).

## SetUserActive

This class is used to set the authenticated user's status to active. Requires the users:write permission.

[API documentation](https://api.slack.com/methods/users.setActive).

## SetUserPresence

This class is used to set the authenticated user's presence to away or to auto (whatever they have set normally). Requires the users:write permission.

[API documentation](https://api.slack.com/methods/users.setPresence).

## SetUserSnooze

This class is used to set the authenticated user to snooze for a given amount of time. Requires the dnd:write permission.

[API documentation](https://api.slack.com/methods/dnd.setSnooze).

## SetUserProfile

This class is used to set a user's profile information Setting user information other than the authenticated user requires a paid team. Requires the users:profile:write permission.

[API documentation](https://api.slack.com/methods/users.profile.set).

## MeMessagePost

This class is used to send a me message from the authenticated user. A me message is a basic message italicized. Requires the chat:write:user permission.

[API documentation](https://api.slack.com/methods/chat.meMessage).

## EditMessage

This class is used to edit a message. Requires the chat:write:bot (as bot user) chat:write:user (as authenticated user) permissions.

[API documentation](https://api.slack.com/methods/chat.update).

## SetUserGroupsUsers

This class is used to set the users of a usergroup. Requires the usergroups:read permission and a paid Slack team.

[API documentation](https://api.slack.com/methods/usergroups.users.update).

## SetUsergroup

This class is used to set the properties of a usergroup. Requires the usergroups:write permission and a paid Slack team.

[API documentation](https://api.slack.com/methods/usergroups.update).

## EnableUsergroup

This class is used to enable a disabled usergroup. Requires the usergroups:write permission and a paid Slack team.

[API documentation](https://api.slack.com/methods/usergroups.enable).

##DisableUsergroup

This class is used to disable a usergroup. Requires the usergroups:write permission and a paid Slack team.

[API documentation](https://api.slack.com/methods/usergroups.disable).

## CreateUsergroup

This class is used to create a usergroup. Requires the usergroups:write permission and a paid Slack team.

[API documentation](https://api.slack.com/methods/usergroups.create).

## RenameChannel

This class is used to rename a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.rename), [private channel API documentation](https://api.slack.com/methods/groups.rename).

## CreateChannel

This class is used to create a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.create), [private channel API documentation](https://api.slack.com/methods/groups.create).

## UnArchiveChannel

This class is used to unarchive a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.unarchive), [private channel API documentation](https://api.slack.com/methods/groups.unarchive).

## ArchiveChannel

This class is used to rename a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.archive), [private channel API documentation](https://api.slack.com/methods/groups.archive).

## LeaveChannel

This class is used to make the authenticated user leave a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.rename), [private channel API documentation](https://api.slack.com/methods/groups.rename).

## KickChannel

This class is used to kick a user from a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.kick), [private channel API documentation](https://api.slack.com/methods/groups.kick).

## InviteChannel

This class is used to invite a user to a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.invite), [private channel API documentation](https://api.slack.com/methods/groups.invite).

## CreateChildPrivateChannel

This class is used to make a child channel from a given private channel. The given channel is renamed to end with '-archived'. A new channel is made with the original channel's name and adds all the members from that channel. Requires the groups:write permission.

[API documentation](https://api.slack.com/methods/groups.createChild).

## JoinPublicChannel

This class is used to join a public channel. If a the name of the channel is not of an existing one, a new channel will be made. Requires the channels:write permission.

[API documentation](https://api.slack.com/methods/channels.join).

## OpenDirectChannel

This class is used to open a direct channel between the authenticated user and a given user. This means that user will be added onto the left hand sidebar. Requires the im:write permission.

[API documentation](https://api.slack.com/methods/im.open).

## OpenMultiDirectChannel

This class is used to open a multi direct channel between the authenticated user and a given user. This means that channel will be added onto the left hand sidebar. Requires the mpim:write permission.

[API documentation](https://api.slack.com/methods/mpim.open).

## OpenPrivateChannel

This class is used to open a private channel. This means that channel will be put into view of added users. Requires the groups:write permission.

[API documentation](https://api.slack.com/methods/groups.open).

## CloseChannel

This class is used to close a direct, multi direct or private channel. This means that channel will be removed from the view of any users that have it open. Requires the im:write (direct), mpim:write (multi direct) and groups:write (private) permissions.

[Direct API documentation](https://api.slack.com/methods/im.open), [multi direct API documentation](https://api.slack.com/methods/mpim.open), [private API documentation](https://api.slack.com/methods/groups.open).

## SetChannelTopic

This class is used to set the topic of a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.setTopic), [private channel API documentation](https://api.slack.com/methods/groups.setTopic).

## SetChannelPurpose

This class is used to set the purpose a public or private channel. Requires the channels:write permission for a public channel and groups:write permission for a private channel.

[Public channel API documentation](https://api.slack.com/methods/channels.setPurpose), [private channel API documentation](https://api.slack.com/methods/groups.setPurpose).

## CloseChannel

This class is used to set the reading cursor channel. This means that messages below the cursor will be marked as unread. Requires the im:write (direct), mpim:write (multi direct),groups:write (private) and channels:write (public) permissions.

[Direct API documentation](https://api.slack.com/methods/im.mark), [multi direct API documentation](https://api.slack.com/methods/mpim.mark), [private API documentation](https://api.slack.com/methods/groups.mark), [public API documentation](https://api.slack.com/methods/channels.mark).

## SlashMessagePost

This class is used to send a message in response to a slash command. It implements the IMessageComponent interface, meaning it has an available Build() method. The Dictionary made by Build should be returned by the slash command API controller in order to send the message. That is why SlashMessagePost does not actually make or receive an API call request.
