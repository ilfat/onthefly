using System.Threading.Tasks;

namespace OnTheFly.Core.Api
{
    public interface ITravelPayoutsApi
    {
        Task<PlacesResponse[]> GetPlaces(string term, string locale = "ru", string[] types = null);
    }
}