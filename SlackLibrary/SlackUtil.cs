using SlackITSupport.SlackLibrary.Events.Users;
using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary
{
    /**
     * Class for small, static methods that perform common tasks.
     */
    public static class SlackUtil
    {
        /**
         * Method that finds the username for a given user ID.
         * @param token - The token for the app.
         * @param userId - The ID to find the username for.
         * @return Task<string> The username.
         */
        public static async Task<string> UserIdToName(string token, string userId)
        {
            JsonUser user = await new GetUser(token, userId).Get();
            if (user == null || !user.Ok)
            {
                return "";
            }
            return user.User.Name;
        }
    }
}