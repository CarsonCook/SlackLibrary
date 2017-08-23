using SlackITSupport.SlackLibrary.JsonParsing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary
{
    /**
     * Parent Get call class. Provides a method for which to make the Slack API Get call and 
     * return an object representing the retrieval. Also provides a start to implementing 
     * BuildRequest() where the item ID is added to the request Dictionary.
     * 
     * Children delete classes are forced to implement a public Get() method that is used by clients
     * to actually perform the retrieval. This method should call base.BuildRequest() and add any other
     * needed information to the request Dictionary. Then it should return base.FireRequest().
     */
    public abstract class SlackApiGet<T> : SlackApiCall<T> where T : SlackApiResponse
    {
        /**
         * Protected constructor so that client classes cannot accidentally invoke it. Client code should only work with children Get classes.
         * 
         * @param token - The Slack bot token.
         * @param identifier - The ID of the item being referenced.
         * @param itemType - The type of the item being referenced.
         * @param itemType - The type of the item being referenced.
         * @param channelType - The type of the channel being referenced.
         * @param itemType - The type of the item being referenced.
         */
        protected SlackApiGet(string token) : base(token)
        {
        }

        /**
         * The only method visible to the client; it is used to perform the get after a get class instance has been made.
         * 
         * @return Task<T> - An object containing the infromation that was retrieved.
         */
        public async Task<T> Get()
        {
            T reactionResponse = await base.FireRequest();
            if (reactionResponse == null || !reactionResponse.Ok) //since T must be of type SlackApiResponse, there is always an Ok field
            {
                return null;
            }
            return reactionResponse;
        }
    }
}