using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Delete
{
    /*
     * Class that deletes the users' profile photo. 
     * 
     * Requires users.profile:write permission.
     */
    public class ProfilePicDelete : SlackApiDelete
    {
        //ItemType does not matter and can't put null
        public ProfilePicDelete(string token) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.DELETE_PROFILE_PIC;
        }
    }
}