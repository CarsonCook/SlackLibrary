using SlackITSupport.Models.SlackLibrary.Events.Search;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Events.Search
{
    /**
     * Class that retrieves one message from a given Slack channel.
     * 
     * This class inherits FindMessages and changes no functionality; it just
     * enforces the timestamps of lastest and newest being the same, and inclusive being true.
     * 
     * Requires the channels:history, groups:history, im:history and mpim:history permissions.
     */
    public class FindMessage : FindMessages
    {
        /**
         * @param token - The Bot, Workspace or User token of the app.
         * @param channel - The ID of the channel holding the message.
         * @param ts - The timestamp of the message being found.
         * @param channelType - Signifies whether the message is in a public, private, direct or multi-party channel.
         */
        public FindMessage(string token, string channel, string ts, ChannelType channelType) :
            base(token, channel, ts, ts, true, channelType)
        {
        }

        /**
         * Constructor that allows for the option to show the unread count of the found message.
         * 
         * @param token - The Bot, Workspace or User token of the app.
         * @param channel - The ID of the channel holding the message.
         * @param ts - The timestamp of the message being found.
         * @param channelType - Signifies whether the message is in a public, private, direct or multi-party channel.
         * @param unreads - Signifies whether the unread count is shown or not.
         */
        public FindMessage(string token, string channel, string ts, ChannelType channelType, bool unreads) :
            base(token, channel, ts, ts, true, channelType, unreads, 1)
        {
        }
    }
}