using System.Net.Http;

namespace SlackITSupport.SlackLibrary.SlackConstants
{
    /**
     * Enumerations for specifying details about Slack API calls.
     */
    public enum ItemType { FILE, FILE_COMMENT, MESSAGE, REMINDER, CHANNEL };
    public enum ChannelType { PUBLIC, PRIVATE, DIRECT, MULTI_DIRECT };

    /**
     * Class holding miscellaneous constants used in the Slack Library.
     * All variables are public and either const or static readonly.
     */
    public static class Constants
    {
        public static readonly HttpClient client = new HttpClient();

        //dictionary values
        public const string VISIBLE_TO_ALL = "in_channel";
        public const string NO_VISIBLE_TO_ALL = "ephermal";
        public const string STYLE_DEFAULT = "default";
        public const string STYLE_PRIMARY = "primary";
        public const string STYLE_DANGER = "danger";
        public const string BUTTON = "button";
        public const string SELECT = "select";
        public const string SORT_TIMESTAMP = "timestamp";
        public const string SORT_SCORE = "score";
        public const string SORT_DIR_ASC = "asc";
        public const string SORT_DIR_DESC = "desc";
        public const string FULL = "full";

        //api response keys
        public const string API_CALL_OK = "ok";
        public const string MESSAGE_POST_ERROR = "error";
        public const string MESSAGE_JSON_PREFIX = "payload=";

        //search specifiers
        public const string SEARCH_CHANNEL_SPECIFIER = "in:";
        public const string SEARCH_HAS_REACTION = "has:reaction";
    }
}