using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing;
using SlackITSupport.SlackLibrary.SlackConstants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary
{
    public abstract class SlackApiCall<T> where T : SlackApiResponse
    {
        private string _token;

        /**
         * Protected constructor so that client classes cannot accidentally invoke it. Client code should only work with specific children classes.
         * 
         * @param token - The Slack bot token.
         */
        protected SlackApiCall(string token)
        {
            _token = token;
        }

        /**
         * Method that starts creating the request Dictionary for a delete call.
         * Virtual so that children classes defining what kind of API call is made can add to the request Dictionary before specific leaf classes
         * call it.
         *
         * @return Dictionary<string, string> - The request Dictionary. Holds the token and item ID.
         */
        protected virtual Dictionary<string, string> BuildRequest()
        {
            return new Dictionary<string, string>
            {
                {DicKeys.TOKEN,_token }
            };
        }

        /**
         * Method that sends the API call in proper format and receive and parse the response.
         * 
         * @return Task<T> - The return type will change depending on the type of call made.
         */
        protected async Task<T> FireRequest()
        {
            try
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(BuildRequest());
                HttpResponseMessage response = await Constants.client.PostAsync(GetApiUrl(), content);
                string responseValString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseValString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Method that leaf classes will define to return the URL for the API call.
         * 
         * @return string - The API URL.
         */
        protected abstract string GetApiUrl();        
    }
}