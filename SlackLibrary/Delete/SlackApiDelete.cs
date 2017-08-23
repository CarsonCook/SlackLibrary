using SlackITSupport.SlackLibrary.JsonParsing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary.Delete
{
    /**
     * Parent delete call class. Provides a method for which to make the Slack API delete call and 
     * return a bool representing the success of the call. Also provides a start to implementing 
     * BuildRequest() where the item ID is added to the request Dictionary.
     * 
     * Children delete classes are forced to implement a public Delete() method that is used by clients
     * to actually perform the deletion. This method should call base.BuildRequest() and add any other
     * needed information to the request Dictionary. Then it should return base.FireRequest().
     */
    public abstract class SlackApiDelete  : SlackApiCall<SlackApiResponse>
    {
        /**
         * Protected constructor so that client classes cannot accidentally invoke it. Client code should only work with children delete classes.
         * 
         * @param token - The Slack bot token.
         * @param identifier - The ID of the item being referenced.
         */
        protected SlackApiDelete(string token) : base(token)
        {
        }

        /**
         * The only method visible to the client; it is used to perform the delete after a delete class instance has been made.
         * 
         * @return Task<bool> - bool that represents whether the delete was successful or not.
         */
        public async Task<bool> Delete()
        {
            SlackApiResponse response = await base.FireRequest();
            return response != null ? response.Ok : false;
        }
    }
}