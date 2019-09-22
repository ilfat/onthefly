using Newtonsoft.Json;
using OnTheFly.Core.ViewModels.FindTickets;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnTheFly.Core.Api
{
    public class AviasalesApi : IAviasalesApi
    {
        private HttpClient _httpClient;
        private string _serverAddress = "http://map.aviasales.ru";

        public AviasalesApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SupportedDirectionsResponse> GetSupportedDirections(string originIata, bool oneWay = true, string locale = "ru")
        {
            var query = string.Format("{0}/supported_directions.json?origin_iata={1}&one_way={2}&locale={3}", _serverAddress, originIata, oneWay, locale);
            var result = await _httpClient.GetStringAsync(query);
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<SupportedDirectionsResponse>(result, jsonSettings);
        }

        public async Task<PricesResponse[]> GetPrices(string originIata, bool oneWay = true, string locale = "ru")
        {
            var query = string.Format("{0}/prices.json?origin_iata={1}&one_way={2}&locale={3}", _serverAddress, originIata, oneWay, locale);
            var result = await _httpClient.GetStringAsync(query);
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<PricesResponse[]>(result, jsonSettings);
        }
    }
}
