using SlackITSupport.SlackLibrary.JsonParsing.IdentityJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Users
{
    /**
     * Class used to retrieve personal information about users logging in.
     * 
     * Requires the identity.basic permission, but if the user picture URLs,
     * user email and team name are to be retrieved, the identity.avatar,
     * identity.email and identity.team permissions are needed.
     * 
     * An app with any other permissions cannot have any identity permissions.
     */
    public class GetUserIdentity : SlackApiGet<JsonIdentityResponse>
    {
        /**
         * @param token - The app User token.
         */
        public GetUserIdentity(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_USER_IDENTITY;
        }
    }
}