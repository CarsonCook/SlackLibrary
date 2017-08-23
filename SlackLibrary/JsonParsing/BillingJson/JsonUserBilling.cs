using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.BillingJson
{
    public class JsonUserBilling
    {
        [JsonProperty("billing_active")]
        public bool BillingActive { get; set; }
    }
}