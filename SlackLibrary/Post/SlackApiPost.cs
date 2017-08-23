using SlackITSupport.SlackLibrary.JsonParsing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary.Post
{
    /**
     * Class that defines how an addition to Slack is made. For example, sending a message
     * or reactioning to one.
     * 
     * Children classes must implement GetIdentifierKey(), GetDataKey() and GetApiUrl() so that BuildRequest()
     * and FireRequest() can work. These are usually just returning a DicKeys or ApiUrls value.
     * Children classes usually should also override BuildRequest(), call base.BuildRequest() and 
     * then add more key-value pairs as needed.
     */
    public abstract class SlackApiPost : SlackApiCall<SlackApiResponse>
    {
        /**          
         * @param token - The token of the app.
         * @param parentData - Data in the call, often a parent identifier for something like a message - e.g. channel ID.
         * @param data - More data in the call, often a child identifier, for example a message timestamp.
         * @param postType - Signifies what the corresponding key for the given data is.
         */
        protected SlackApiPost(string token) : base(token)
        {
        }

        /**
         * The only method visible to the client; it is used to perform the addition after an addition class instance has been made.
         * 
         * @return Task<bool> - bool that represents whether the addition was successful or not.
         */
        public async Task<bool> Post()
        {
            SlackApiResponse response = await base.FireRequest();
            return response != null ? response.Ok : false;
        }
    }
}