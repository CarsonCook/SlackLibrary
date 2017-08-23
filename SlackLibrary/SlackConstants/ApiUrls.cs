namespace SlackITSupport.SlackLibrary.SlackConstants
{
    /**
     * Class that holds the Slack API URLs. All are public const strings.
     */
    public static class ApiUrls
    {
        /*
         * Delete - DONE
         * 
         * These API calls will simulate user actions that remove things from Slack.
         */
        //done *.delete*
        public const string DELETE_PROFILE_PIC = "https://slack.com/api/users.deletePhoto";
        public const string DELETE_FILE_COMMENT = "https://slack.com/api/files.comments.delete";

        //done .delete
        public const string DELETE_REMINDER = "https://slack.com/api/reminders.delete";
        public const string DELETE_FILE = "https://slack.com/api/files.delete";
        public const string DELETE_MESSAGE = "https://slack.com/api/chat.delete";

        //done .remove
        public const string DELETE_REACTION = "https://slack.com/api/reactions.remove";
        public const string DELETE_STAR = "https://slack.com/api/stars.remove";
        public const string DELETE_PIN = "https://slack.com/api/pins.remove";

        /*
         * Get - DONE
         * 
         * These API calls will retrieve information from Slack.
         */
        //done .history
        public const string GET_PUBLIC_CHANNEL_HISTORY = "https://slack.com/api/channels.history";
        public const string GET_PRIVATE_CHANNEL_HISTORY = "https://slack.com/api/groups.history";
        public const string GET_DIRECT_CHANNEL_HISTORY = "https://slack.com/api/im.history";
        public const string GET_MULTI_DIRECT_CHANNEL_HISTORY = "https://slack.com/api/mpim.history";

        //done search.*
        public const string SEARCH_MESSAGES = "https://slack.com/api/search.messages";
        public const string SEARCH_ITEMS = "https://slack.com/api/search.all";
        public const string SEARCH_FILES = "https://slack.com/api/search.files";

        //done .get
        public const string GET_REACTIONS = "https://slack.com/api/reactions.get";

        //done *.get
        public const string GET_USER_PROFILE = "https://slack.com/api/users.profile.get";
        public const string GET_TEAM_PROFILE = "https://slack.com/api/team.profile.get";

        //done .get*
        public const string GET_PRESENCE = "https://slack.com/api/users.getPresence";

        //done .list
        public const string GET_ALL_USERS = "https://slack.com/api/users.list";
        public const string GET_USERGROUPS = "https://slack.com/api/usergroups.list";
        public const string GET_USERGROUP_USERS = "https://slack.com/api/usergroups.users.list";
        public const string GET_ALL_REMINDERS = "https://slack.com/api/reminders.list";
        public const string GET_ALL_CHANNELS_PUBLIC = "https://slack.com/api/channels.list";
        public const string GET_ALL_CHANNELS_PRIVATE = "https://slack.com/api/groups.list";
        public const string GET_ALL_CHANNELS_DIRECT = "https://slack.com/api/ims.list";
        public const string GET_ALL_CHANNELS_MULTI_DIRECT = "https://slack.com/api/mpims.list";
        public const string GET_EMOJIS = "https://slack.com/api/emoji.list";
        public const string GET_CHANNEL_PINNED = "https://slack.com/api/pins.list";
        public const string GET_ALL_USER_STARRED = "https://slack.com/api/stars.list";
        public const string GET_ALL_USER_REACTED_TO = "https://slack.com/api/reactions.list";
        public const string GET_FILES = "https://slack.com/api/files.list";

        //done .info
        public const string GET_USER_INFO = "https://slack.com/api/users.info";
        public const string GET_CHANNEL_PUBLIC = "https://slack.com/api/channels.info";
        public const string GET_CHANNEL_PRIVATE = "https://slack.com/api/groups.info";
        public const string GET_APP_PERMISSIONS = "https://slack.com/api/apps.permissions.info";
        public const string GET_BOT_USER = "https://slack.com/api/bots.info";
        public const string GET_USER_DND = "https://slack.com/api/dnd.info";
        public const string GET_FILE = "https://slack.com/api/files.info";
        public const string GET_TEAM = "https://slack.com/api/team.info";
        public const string GET_REMINDER = "https://slack.com/api/reminders.info";

        //done .*info
        public const string GET_TEAM_DND = "https://slack.com/api/dnd.teamInfo";
        public const string GET_BILLING_INFO = "https://slack.com/api/team.billableInfo";

        //done .replies
        public const string GET_DIRECT_THREAD = "https://slack.com/api/im.replies";
        public const string GET_MULTI_DIRECT_THREAD = "https://slack.com/api/mpim.replies";
        public const string GET_PUBLIC_THREAD = "https://slack.com/api/channels.replies";
        public const string GET_PRIVATE_THREAD = "https://slack.com/api/groups.replies";

        //done .*Logs
        public const string GET_TEAM_ACCESS_LOGS = "https://slack.com/api/team.accessLogs";
        public const string GET_TEAM_INTEGRATION_LOGS = "https://slack.com/api/team.integrationLogs";

        //done .identity
        public const string GET_USER_IDENTITY = "https://slack.com/api/users.identity";

        /*
         * Post
         * 
         * These API calls will simulate user actions that add or change things within Slack.
         */
        //done .post*
        public const string POST_MESSAGE = "https://slack.com/api/chat.postMessage";
        public const string POST_EPHEMERAL_MESSAGE = "https://slack.com/api/chat.postEphemeral";

        public const string COMPELTE_REMINDER = "https://slack.com/api/reminders.complete";

        //done .add
        public const string POST_REACTION = "https://slack.com/api/reactions.add";
        public const string PIN_ITEM = "https://slack.com/api/pins.add";
        public const string CREATE_REMINDER = "https://slack.com/api/reminders.add";
        public const string ADD_STAR = "https://slack.com/api/stars.add";
        public const string FILE_COMMENT_POST = "https://slack.com/api/files.comments.add";

        //done .end*
        public const string END_DND = "https://slack.com/api/dnd.endDnd";
        public const string END_SNOOZE = "https://slack.com/api/dnd.endSnooze";

        // .set*
        public const string SET_SNOOZE = "https://slack.com/api/dnd.setSnooze";
        public const string SET_USER_ACTIVE = "https://slack.com/api/users.setActive";
        public const string SET_USER_PRESENCE = "https://slack.com/api/users.setPresence";
        public const string SET_PUBLIC_CHANNEL_PURPOSE = "https://slack.com/api/channels.setPurpose";
        public const string SET_PRIVATE_CHANNEL_PURPOSE = "https://slack.com/api/groups.setPurpose";
        public const string SET_PUBLIC_CHANNEL_TOPIC = "https://slack.com/api/channels.setTopic";
        public const string SET_PRIVATE_CHANNEL_TOPIC = "https://slack.com/api/groups.setTopic";
        public const string SET_USER_PROFILE = "https://slack.com/api/users.profile.set";
        //just need users.setPhoto

        //done *.edit
        public const string EDIT_FILE_COMMENT = "https://slack.com/api/files.comments.edit";

        //done *URL
        public const string SHARE_FILE_URL = "https://slack.com/api/files.sharedPublicURL";
        public const string PROTECT_FILE_URL = "https://slack.com/api/files.revokePublicURL";

        //done *.update
        public const string SET_USERGROUPS_USERS = "https://slack.com/api/usergroups.users.update";
        public const string SET_USERGROUP = "https://slack.com/api/usergroups.update";
        public const string UPDATE_MESSAGE = "https://slack.com/api/chat.update";

        //done .enable
        public const string ENABLE_USERGROUP = "https://slack.com/api/usergroups.enable";

        //done .disable
        public const string DISABLE_USERGROUP = "https://slack.com/api/usergroups.disable";

        //done .close
        public const string CLOSE_DIRECT_CHANNEL = "https://slack.com/api/im.close";
        public const string CLOSE_MULTI_DIRECT_CHANNEL = "https://slack.com/api/mpim.close";
        public const string CLOSE_PRIVATE_CHANNEL = "https://slack.com/api/groups.close";

        //done .mark
        public const string SET_PUBLIC_CHANNEL_CURSOR = "https://slack.com/api/channels.mark";
        public const string SET_PRIVATE_CHANNEL_CURSOR = "https://slack.com/api/groups.mark";
        public const string SET_DIRECT_CHANNEL_CURSOR = "https://slack.com/api/im.mark";
        public const string SET_MULTI_DIRECT_CHANNEL_CURSOR = "https://slack.com/api/mpim.mark";

        //done .open
        public const string OPEN_DIRECT_CHANNEL = "https://slack.com/api/im.open";
        public const string OPEN_MULTI_DIRECT_CHANNEL = "https://slack.com/api/mpim.open";
        public const string OPEN_PRIVATE_CHANNEL = "https://slack.com/api/groups.open";

        //done .create
        public const string CREATE_USERGROUP = "https://slack.com/api/usergroups.create";
        public const string CREATE_PRIVATE_CHANNEL = "https://slack.com/api/groups.create";
        public const string CREATE_PUBLIC_CHANNEL = "https://slack.com/api/channels.create";

        //done .create*
        public const string CREATE_CHILD_PRIVATE_CHANNEL = "https://slack.com/api/groups.createChild";

        //done .meMessage
        public const string POST_ME_MESSAGE = "https://slack.com/api/chat.meMessage";

        //done .join
        public const string JOIN_PUBLIC_CHANNEL = "https://slack.com/api/channels.join";

        //done .leave
        public const string LEAVE_PRIVATE_CHANNEL = "https://slack.com/api/groups.leave";
        public const string LEAVE_PUBLIC_CHANNEL = "https://slack.com/api/channels.leave";

        //done .rename
        public const string RENAME_PUBLIC_CHANNEL = "https://slack.com/api/channels.rename";
        public const string RENAME_PRIVATE_CHANNEL = "https://slack.com/api/groups.rename";

        //done .invite
        public const string INVITE_PUBLIC_CHANNEL = "https://slack.com/api/channels.invite";
        public const string INVITE_PRIVATE_CHANNEL = "https://slack.com/api/groups.invite";

        //done .kick
        public const string KICK_PUBLIC_CHANNEL = "https://slack.com/api/channels.kick";
        public const string KICK_PRIVATE_CHANNEL = "https://slack.com/api/groups.kick";

        //done .archive
        public const string ARCHIVE_PUBLIC_CHANNEL = "https://slack.com/api/channels.archive";
        public const string ARCHIVE_PRIVATE_CHANNEL = "https://slack.com/api/groups.archive";

        //done .*archive
        public const string UNARCHIVE_PUBLIC_CHANNEL = "https://slack.com/api/channels.unarchive";
        public const string UNARCHIVE_PRIVATE_CHANNEL = "https://slack.com/api/groups.unarchive";
    }
}