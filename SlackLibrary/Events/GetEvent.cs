using Newtonsoft.Json;
using SlackITSupport.Models;
using SlackITSupport.SlackLibrary.JsonParsing.EventJson;

namespace SlackITSupport.SlackLibrary.Events
{
    /**
     * Class that helps handling an event JSON object from Slack.
     */
    public class GetEvent
    {
        /**
         * Method that turns the Slack event JSON string into an object.
         * 
         * @return JsonEvent - An object holding all of the event information.
         */
        public static JsonEvent Get(string request)
        {
            return JsonConvert.DeserializeObject<JsonEvent>(request);
        }

        /**
         * Method that determines what kind of event happened. Used for when the Slack 
         * information has two events with the same name but are slightly different.
         * For example, a message event and a reply.
         * 
         * @return string - The name of the event that occurred.
         */
        public static string DiagnoseEvent(JsonEvent slackEvent)
        {
            if (slackEvent == null || slackEvent.Event == null || slackEvent.Event.Type == null)
            {
                return ControllerConstants.NOT_EVENT_MESSAGE;
            }

            if (slackEvent.Event.Type == SlackConstants.Events.MESSAGE_SENT)
            {
                return slackEvent.Event.Thread_ts == null ? SlackConstants.Events.MESSAGE_SENT : SlackConstants.Events.REPLY_SENT;
            }
            return slackEvent.Event.Type;
        }
    }
}