using Newtonsoft.Json;

namespace OnTheFly.Core.Api
{
    public class Direction
    {
        [JsonProperty(PropertyName = "iata")]
        public string Iata;
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "country")]
        public string Country;
        [JsonProperty(PropertyName = "coordinates")]
        public double?[] Coordinates;
    }
}