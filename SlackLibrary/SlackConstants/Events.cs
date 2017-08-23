namespace SlackITSupport.SlackLibrary.SlackConstants
{
    /**
     * Class that holds the different types of events that can happen in Slack. All are public const strings.
     */
    public static class Events
    {
        public const string APP_UNINSTALLED = "app_uninstalled";
        public const string CHANNEL_ARCHIVE = "channel_archive";
        public const string CHANNEL_CREATED = "channel_created";
        public const string CHANNEL_DELETED = "channel_deleted";
        public const string CHANNEL_HISTORY = "channel_history_changed";
        public const string CHANNEL_RENAMED = "channel_rename";
        public const string CHANNEL_UNARCHIVED = "channel_unarchive";
        public const string DND_UPDATED_CURRENT_USER = "dnd_updated";
        public const string DND_UPDATED_OTHER_USER = "dnd_updated_user";
        public const string TEAM_EMAIL_CHANGED = "email_domain_changed";
        public const string EMOJI_CHANGED = "emoji_changed";
        public const string FILE_CHANGED = "file_change";
        public const string FILE_COMMENT_ADDED = "file_comment_added";
        public const string FILE_COMMENT_DELETED = "file_comment_deleted";
        public const string FILE_COMMENT_EDITED = "file_comment_edited";
        public const string FILE_CREATED = "file_created";
        public const string FILE_DELETED = "file_deleted";
        public const string FILE_PUBLIC = "file_public";
        public const string FILE_SHARED = "file_shared";
        public const string FILE_UNSHARED = "file_unshared";
        public const string GRID_MIGRATION_FINISHED = "grid_migration_finished";
        public const string GRID_MIGRATION_STARTED = "grid_migration_started";
        public const string PRIVATE_CHANNEL_ARCHIVED = "group_archive";
        public const string PRIVATE_CHANNEL_CLOSED = "group_close";
        public const string PRIVATE_CHANNEL_HISTORY = "group_history_changed";
        public const string PRIVATE_CHANNEL_OPENED = "group_open";
        public const string PRIVATE_CHANNEL_RENAMED = "group_rename";
        public const string PRIVATE_CHANNEL_UNARCHIVED = "group_unarchive";
        public const string DIRECT_CHANNEL_CLOSED = "im_close";
        public const string DIRECT_CHANNEL_CREATED = "im_created";
        public const string DIRECT_CHANNEL_HISTORY = "im_history_changed";
        public const string DIRECT_CHANNEL_OPENED = "im_open";
        public const string LINK_SHARED = "link_shared";
        public const string JOINED_CHANNEL = "member_joined_channel";
        public const string LEFT_CHANNEL = "member_left_channel";
        public const string MESSAGE_SENT = "message";
        public const string MESSAGE_POSTED = "message.channels";
        public const string REPLY_SENT = "message";
        public const string PRIVATE_CHANNEL_MESSAGE_POSTED = "message.groups";
        public const string DIRECT_CHANNEL_MESSAGE_POSTED = "message.im";
        public const string MULTI_DIRECT_CHANNEL_MESSAGE_POSTED = "message.mpim";
        public const string PIN_ADDED = "pin_added";
        public const string PIN_REMOVED = "pin_removed";
        public const string REACTION_ADDED = "reaction_added";
        public const string REACTION_REMOVED = "reaction_removed";
        public const string STAR_ADDED = "star_added";
        public const string STAR_REMOVED = "star_removed";
        public const string SUBTEAM_CREATED = "subteam_created";
        public const string SUBTEAM_MEMBERS_CHANGED = "subteam_members_changed";
        public const string SUBTEAM_SELF_ADDED = "subteam_self_added";
        public const string SUBTEAM_SELF_REMOVED = "subteam_self_removed";
        public const string SUBTEAM_UPDATED = "subteam_updated";
        public const string TEAM_DOMAIN_CHANGE = "team_domain_change";
        public const string TEAM_JOINED = "team_join";
        public const string TEAM_RENAMED = "team_rename";
        public const string APP_TOKENS_REVOKED = "tokens_revoked";
        public const string CHALLENGE_URL_VERIFICATION = "url_verification";
        public const string USER_CHANGE = "user_change";
    }
}