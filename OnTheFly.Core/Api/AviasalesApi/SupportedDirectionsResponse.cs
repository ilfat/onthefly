using Newtonsoft.Json;

namespace OnTheFly.Core.Api
{
    public class SupportedDirectionsResponse
    {
        [JsonProperty(PropertyName = "origin")]
        public Direction Origin;
        [JsonProperty(PropertyName = "directions")]
        public Direction[] Directions;
    }
}