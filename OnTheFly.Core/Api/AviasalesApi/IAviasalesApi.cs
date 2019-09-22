using OnTheFly.Core.ViewModels.FindTickets;
using System.Threading.Tasks;

namespace OnTheFly.Core.Api
{
    public interface IAviasalesApi
    {
        Task<SupportedDirectionsResponse> GetSupportedDirections(string originIata, bool oneWay = true, string locale = "ru");
        Task<PricesResponse[]> GetPrices(string originIata, bool oneWay = true, string locale = "ru");
    }
}
