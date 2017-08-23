using SlackITSupport.Models.SlackLibrary.Get;
using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;
using System.Threading.Tasks;
using SlackITSupport.Models.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    public class GetPublicChannel : SlackApiGet<JsonGetPublicChannel>
    {
        //ItemType arbitrary
        public GetPublicChannel(string token, string channelId) : base(token, channelId, ItemType.FILE, ChannelType.PUBLIC, GetRequestType.CHANNEL_PUBLIC)
        {
        }

        public override async Task<JsonGetPublicChannel> Get()
        {
            JsonGetPublicChannel channel = await base.FireRequest(base.BuildRequest());
            if (channel == null || !channel.Ok)
            {
                return null;
            }
            return channel;
        }
    }
}