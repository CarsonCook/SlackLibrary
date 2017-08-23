using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamProfileJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Team
{
    public enum VisibilityType { ALL, VISIBLE, HIDDEN };

    /**
     * Class used to get information about the app's Slack team.
     * 
     * Requires the users.profile:read permission.
     */
    public class GetTeamProfile : SlackApiGet<JsonTeamProfileResponse>
    {
        private VisibilityType _visibilityType;

        /**
         * @param token - The app Workspace or User token.
         * @param visibilityType - Signifies whether all profile fields, visible fields or hidden fields will be shown.
         */
        public GetTeamProfile(string token, VisibilityType visibilityType) : base(token) //don't know what the data value is yet
        {
            _visibilityType = visibilityType;
        }

        /**
         * Constructor for automatically using a VisibilityType of ALL.
         */
        public GetTeamProfile(string token) : base(token)
        {
            _visibilityType = VisibilityType.ALL;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.VISIBILITY, GetVisibilityString());
            return request;
        }

        protected override string GetApiUrl() => ApiUrls.GET_TEAM_PROFILE;

        /**
         * Method used to get the string value associated with the passed in VisiblityType.
         * 
         * @return string - The string value of _visibilityType
         */
        private string GetVisibilityString()
        {
            switch (_visibilityType)
            {
                case VisibilityType.ALL:
                    return DicKeys.ALL;
                case VisibilityType.HIDDEN:
                    return DicKeys.HIDDEN;
                case VisibilityType.VISIBLE:
                    return DicKeys.VISIBLE;
            }
            return ""; //bad VisibilityType passed in
        }
    }
}