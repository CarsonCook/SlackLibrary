using Newtonsoft.Json;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.JsonParsing.BillingJson
{
    public class JsonBillingResponse : SlackApiResponse
    {
        [JsonProperty("billable_info")]
        public Dictionary<string, JsonUserBilling> BillableInfo { get; set; } //has to be dictionary as the key values are user IDs
                                                                            //-> don't know ahead of time
    }
}