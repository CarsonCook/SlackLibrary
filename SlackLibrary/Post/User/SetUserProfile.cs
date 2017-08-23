using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.UserInfoJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.Post.User
{
    /**
     * Class used to set a user's profile information. If the authenticated user is an admin
     * and the Slack team is paid, then this can be used to set any user's profile. Otherwise
     * it is limited to the authenticated user.
     * 
     * Requires the users:profile:write permission.
     */
    public class SetUserProfile : SlackApiPost
    {
        private string _profileItem, _userId, _value;
        private JsonUserProfile _profile;

        /**
         * Method used to set instance variables in order to avoid constructor repitition.
         * 
         * @param profileItem - Specifies what in the profile is being changed, if only one value is changing.
         * @param userId - Specifies which user's profile is changing, if not the authenticated user's.
         * @param value - Specifices what profileItem's value will be, if only one value is changing.
         * @param profile - Sets the entire profile, if not null.
         */
        private void Initialize(string profileItem, string userId, string value, JsonUserProfile profile)
        {
            _profileItem = profileItem;
            _userId = userId;
            _value = value;
            _profile = profile;
        }

        /**
         * Constructor for setting a single item of the authenticated user's profile.
         * 
         * @param token - The app User token.
         */
        public SetUserProfile(string token, string profileItem, string value) : base(token)
        {
            Initialize(profileItem, "", value, null);
        }

        /**
         * Constructor for setting a single item of a given user's profile.
         * 
         * @param token - The app User token.
         */
        public SetUserProfile(string token, string profileItem, string value, string userId) : base(token)
        {
            Initialize(profileItem, userId, value, null);
        }

        /**
         * Constructor for setting the authenticated user's whole profile.
         * 
         * @param token - The app User token.
         */
        public SetUserProfile(string token, JsonUserProfile profile) : base(token)
        {
            Initialize("", "", "", profile);
        }

        /**
         * Constructor for setting a given user's whole profile.
         * 
         * @param token - The app User token.
         */
        public SetUserProfile(string token, string userId, JsonUserProfile profile) : base(token)
        {
            Initialize("", userId, "", profile);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            //determine if using profile or profileItem/value
            if (_profile != null)
            {
                request.Add(DicKeys.PROFILE, JsonConvert.SerializeObject(_profile));
            }
            else
            {
                request.Add(DicKeys.NAME, _profileItem);
                request.Add(DicKeys.VALUE, _value);
            }
            //determine if using a userId or just authenticated user
            if (_userId != "")
            {
                request.Add(DicKeys.USER, _userId);
            }
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.SET_USER_PROFILE;
        }
    }
}