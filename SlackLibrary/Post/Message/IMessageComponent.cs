using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Message
{
    /**
     * Interface that forces parts of a Slack message to be accessible.
     */
    public interface IMessageComponent
    {

        /*
         * Creates a Dictionary that holds the JSON information for a Slack message to be posted.
         * Uses the instance variables as values for corresponding hardcoded keys defined by Slack API.
         */
        Dictionary<string, dynamic> Build();
    }
}