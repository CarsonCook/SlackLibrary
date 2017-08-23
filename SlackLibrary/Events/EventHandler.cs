using SlackITSupport.SlackLibrary.JsonParsing.EventJson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary.Events
{
    /**
     * Class that will be inherited by specific event type handlers.
     * It means each event handler will have event data and must use a
     * Handle() method to use logic on the events.
     * 
     * Client code will use the HandleEvent() method to check if there
     * are any handler for the given event, and if there are have the event handled.
     */
    public abstract class EventHandler
    {
        protected string _eventToHandle;

        protected EventHandler(string eventToHandle)
        {
            _eventToHandle = eventToHandle;
        }

        /**
         * The only available method to client code, a list of handlers for different events is given and 
         * this method will find the proper one for the given event and call its Handle() method.
         * 
         * This is pretty much a Chain of Command design pattern, allowing one method call (this one)
         * to be used to handle any event. The only new work for a new event is to make the child class of this one
         * implement Handle().
         * 
         * @param handlers - A List of EventHandlers, this list is searched for the proper handler for the given event.
         * @param jsonEvent - The Slack JSON Event object.
         * @return Task<bool> - Signifies if the event was handled properly.
         */
        public static async Task<bool> HandleEvent(List<EventHandler> handlers, JsonEvent jsonEvent)
        {
            //check inputs are ok
            if (jsonEvent == null || handlers == null)
            {
                return false;
            }

            //search for suitable handler for event, if find one have it handle event
            foreach (EventHandler handler in handlers)
            {
                if (handler.CanHandle(jsonEvent))
                {
                    return await handler.Handle(jsonEvent.Event); //only ever use one handler for an event
                }
            }
            return false; //no suitable handler found, event not handled
        }

        /**
         * Method that determines if this instance of EventHandler can handle the event passed in.
         * Used so that HandleEvent() can determine which handler can handle the given event.
         * 
         * @param jsonEvent - The JSON sent by the Slack Events API. Used to determine the type of event.
         * @return bool - Signifies if the event can be handled by this handler.
         */
        protected bool CanHandle(JsonEvent jsonEvent)
        {
            return _eventToHandle == GetEvent.DiagnoseEvent(jsonEvent);
        }

        /**
         * Method that children class wil use to send event data through the logic
         * that will handle the event.
         * 
         * @param eventDetails - The event information.
         * @return bool - Signifies if the event handling succeeded or not.
         */
        protected abstract Task<bool> Handle(JsonEventDetails eventDetails);
    }
}