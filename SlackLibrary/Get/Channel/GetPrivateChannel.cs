using SlackITSupport.Models.SlackLibrary.Get;
using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;
using System.Threading.Tasks;
using SlackITSupport.Models.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    public class GetPrivateChannel : SlackApiGet<JsonGetPrivateChannel>
    {
        //ItemType and ChannelType arbitrary
        public GetPrivateChannel(string token, string channelId) : base(token, channelId, ItemType.FILE, ChannelType.PUBLIC, GetRequestType.CHANNEL_PRIVATE)
        {
        }

        public override async Task<JsonGetPrivateChannel> Get()
        {
            JsonGetPrivateChannel channel = await base.FireRequest(base.BuildRequest());
            if (channel == null || !channel.Ok)
            {
                return null;
            }
            return channel;
        }
    }
}