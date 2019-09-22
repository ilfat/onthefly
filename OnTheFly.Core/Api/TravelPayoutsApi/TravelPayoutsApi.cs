using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnTheFly.Core.Api
{
    public class TravelPayoutsApi : ITravelPayoutsApi
    {
        private HttpClient _httpClient;
        private string _serverAddress = "http://autocomplete.travelpayouts.com";

        public TravelPayoutsApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PlacesResponse[]> GetPlaces(string term, string locale = "ru", string[] types = null)
        {
            if (types == null)
            {
                types = new string[] { "city", "airport" };
            }
            var query = string.Format("{0}/places2?term={1}&locale={2}&types={3}", _serverAddress, term, locale, JsonConvert.SerializeObject(types));
            var result = await _httpClient.GetStringAsync(query);
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<PlacesResponse[]>(result, jsonSettings);
        }
    }
}
