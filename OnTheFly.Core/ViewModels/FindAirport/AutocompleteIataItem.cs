using OnTheFly.Core.Api;

namespace OnTheFly.Core.ViewModels
{
    public class AutocompleteIataItem
    {
        private PlacesResponse _place;

        public AutocompleteIataItem(PlacesResponse place)
        {
            this._place = place;
        }
        public string Content => string.Format("{0}, {1}, {2}", _place.Code, _place.Name, _place.CountryName);
        public string Code => _place.Code;
    }
}