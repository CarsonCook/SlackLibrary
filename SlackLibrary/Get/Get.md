# Get

This folder holds classes used to retrieve information from Slack.

## GetAppPermissions

This class is used to retrieve the permission of the calling application. No permissions required.

[API documentation](https://api.slack.com/methods/apps.permissions.info).

## GetBotUser

This class is used to retrieve information on a bot user. Requires the users:read permission.

[API documentation](https://api.slack.com/methods/bots.info).

## GetChannel

This class is used to retrieve information about a channel. Public or private only, no direct channels. Only private channels that the app has access to. Requires the groups:read (private) and channels:read (public) permissions.

[Public API documentation](https://api.slack.com/methods/channels.info), [private API documentation](https://api.slack.com/methods/groups.info).

## GetChannels

This class is used to retrieve a list of channels in the team. Public, private, direct or multi-direct channels. Only private, direct and multi-direct channels that the app has access to. Requires the im:read {direct), mpim:read (multi-direct), groups:read (private) and channels:read (public) permissions.

[Direct API documentation](https://api.slack.com/methods/im.list), [multi-direct API documentation](https://api.slack.com/methods/mpim.list), [public API documentation](https://api.slack.com/methods/channels.info), [private API documentation](https://api.slack.com/methods/groups.info).

## GetPinned

This class is used to retrieve the files, file comments and messages pinned to a given channel. Requires the pins:read permission.

[API documentation](https://api.slack.com/methods/pins.list).

## GetThread

This class is used to retrieve a thread from a given channel. Public, private, direct or multi-direct channels. Only private, direct and multi-direct channels that the app has access to. Requires the im:read {direct), mpim:read (multi-direct), groups:read (private) and channels:read (public) permissions.

[Direct API documentation](https://api.slack.com/methods/im.history), [multi-direct API documentation](https://api.slack.com/methods/mpim.history), [public API documentation](https://api.slack.com/methods/channels.history), [private API documentation](https://api.slack.com/methods/groups.history).

## GetFile 

This class retrieves a file. Requires the files:read permission.

[API documentation](https://api.slack.com/methods/files.info).

## GetFiles

This class retrieves all files. Requires the files:read permission.

[API documentation](https://api.slack.com/methods/files.list).

## GetReminder

This class retrieves a reminder. Requires the reminders:read permission.

[API documentation](https://api.slack.com/methods/reminders.info).

## GetRemindersForUser

This class retrieves all reminders for a given user. Requires the reminders:read permission.

[API documentation](https://api.slack.com/methods/files.list).

## FindMessage

This class retrieves one message from a given channel. Public, private, direct or multi-direct channels. Only private, direct and multi-direct channels that the app has access to. Requires the im:read {direct), mpim:read (multi-direct), groups:read (private) and channels:read (public) permissions.

[Direct API documentation](https://api.slack.com/methods/im.history), [multi-direct API documentation](https://api.slack.com/methods/mpim.history), [public API documentation](https://api.slack.com/methods/channels.history), [private API documentation](https://api.slack.com/methods/groups.history).

## FindMessages

This class retrieves multiple messages from a given channel. Public, private, direct or multi-direct channels. Only private, direct and multi-direct channels that the app has access to. Requires the im:read {direct), mpim:read (multi-direct), groups:read (private) and channels:read (public) permissions.

[Direct API documentation](https://api.slack.com/methods/im.history), [multi-direct API documentation](https://api.slack.com/methods/mpim.history), [public API documentation](https://api.slack.com/methods/channels.history), [private API documentation](https://api.slack.com/methods/groups.history).

## SlackSearch

This class simulates a search with the Slack search bar. Requires the search:read permission.

[Searching all items API documentation](https://api.slack.com/methods/search.all), [searching files API documentation](https://api.slack.com/methods/search.files), [searching messages API documentation](https://api.slack.com/methods/search.messages).

## GetBilling

This class retrieves the billing information for users. Only available if Slack is being paid for. Requires the admin permission.

[API documentation](https://api.slack.com/methods/team.billableInfo).

## GetTeam

This class is used to retrieve information about the team. Requires the team:read permission.

[API documentation](https://api.slack.com/methods/team.info).

## GetTeamAccessLogs

This class is used to retrieve the team logs (currently only login logs). Only available if Slack is being paid for. Requires the admin permission.

[API documentation](https://api.slack.com/methods/team.accessLogs).

## GetTeamProfile

This class retrieves the team profile. Requires the users.profile:read permission.

[API documentation](https://api.slack.com/methods/team.profile.get).

## GetUserGroups

This class retrieves a list of user groups. Requires the usergroups:read permission.

[API documentation](https://api.slack.com/methods/usergroups.list).

## GetUsersInGroup

This class retrieves a list of users in a given user group. Requires the usergroups:read permission.

[API documentation](https://api.slack.com/methods/usergroups.users.list).

## GetUserDnd

This class retrieves the do not disturb information for a given user. Requires the dnd:read permission.

[API documentation](https://api.slack.com/methods/dnd.info).

## GetUsersDnd

This class retrieves the do not disturb information for multiple users. Requires the dnd:read permission.

[API documentation](https://api.slack.com/methods/dnd.teamInfo).

## GetAllUsers

This class retrieves all of the users in the team. Requires the users:read permission.

[API documentation](https://api.slack.com/methods/users.list).

## GetUser

This class retrieves a user, given their ID. Requires the users:read permission.

[API documentation](https://api.slack.com/methods/users.info).

## GetUserIdentity

This class retrieves personal information of users when they login. Requires the identity.basic permission and for more information the identity.avatar, identity.email and identity.team permissions.

[API documentation](https://api.slack.com/methods/users.identity).

## GetUserPresence

This class retrieves the presence status of a given user. Requires the users:read permission.

[API documentation](https://api.slack.com/methods/users.getPresence).

## GetUserProfile

This class retrieves the profile of a given user. Requires the users.profile:read permission.

[API documentation](https://api.slack.com/methods/users.profile.get).

## GetUserReaction

This class retrieves the items that a given user has reacted to. Requires the reactions:read permission.

[API documentation](https://api.slack.com/methods/reactions.list).

## GetUserStarred

This class retrieves the items that the app authenticated user has starred. Requires the stars:read permission.

[API documentation](https://api.slack.com/methods/stars.list).

## GetEmojis

This class retrieves a list of the custom emojis created. Requires the emojis:read permission.

[API documentation](https://api.slack.com/methods/emojis.list).

## GetItemReactions

This class retrieves a list of the reactions to a given file, file comment or message.  Requires the reactions:read permission.

[API documentation](https://api.slack.com/methods/reactions.get).

## GetTeamIntegrationLogs

This class retrieves information on the integrations of the Slack team. Requires the admin permission.

[API documentation](https://api.slack.com/methods/team.integrationLogs).
