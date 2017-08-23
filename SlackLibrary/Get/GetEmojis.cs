using SlackITSupport.SlackLibrary.JsonParsing;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get
{
    /**
     * Class that retrives the custom emojis for the app's team.
     * 
     * Requires the emoji:read permission.
     */
    public class GetEmojis : SlackApiGet<JsonEmoji>
    {
        public GetEmojis(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_EMOJIS;
        }
    }
}