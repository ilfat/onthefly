using Newtonsoft.Json;

namespace OnTheFly.Core.Api
{
    public class PlacesResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "code")]
        public string Code;
        [JsonProperty(PropertyName = "country_name")]
        public string CountryName;
    }
}
