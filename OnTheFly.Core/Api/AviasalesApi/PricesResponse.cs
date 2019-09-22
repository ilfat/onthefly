using Newtonsoft.Json;

namespace OnTheFly.Core.Api
{
    public class PricesResponse
    {
        [JsonProperty(PropertyName = "destination")]
        public string Destination;
        [JsonProperty(PropertyName = "depart_date")]
        public string DepartDate;
        [JsonProperty(PropertyName = "return_date")]
        public string ReturnDate;
        [JsonProperty(PropertyName = "value")]
        public string Value;
        [JsonProperty(PropertyName = "actual")]
        public bool Actual;
    }
}
