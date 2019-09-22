using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using OnTheFly.Core.Api;
using OnTheFly.Core.ViewModels.FindTickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly.Core.ViewModels
{
    public class FindAirportViewModel : MvxViewModel
    {
        public FindAirportViewModel(IAviasalesApi aviasalesApi, ITravelPayoutsApi travelPayoutsApi, IMvxMessenger mvxMessenger, IMvxNavigationService navigationService)
        {
            _aviasalesApi = aviasalesApi;
            _travelPayoutsApi = travelPayoutsApi;
            _mvxMessenger = mvxMessenger;
            _navigationService = navigationService;
        }
        public void Init()
        {
        }


        private string _Filter = "";
        private IAviasalesApi _aviasalesApi;
        private ITravelPayoutsApi _travelPayoutsApi;
        private IMvxMessenger _mvxMessenger;
        private IMvxNavigationService _navigationService;
        private MvxObservableCollection<AutocompleteIataItem> _AirportsAutocomplete = new MvxObservableCollection<AutocompleteIataItem>();
        private bool _autocompleteRequestInProgress;

        public MvxObservableCollection<AutocompleteIataItem> AirportsAutocomplete
        {
            get { return _AirportsAutocomplete; }
            set
            {
                _AirportsAutocomplete = value;
                RaisePropertyChanged(() => AirportsAutocomplete);
            }
        } 

        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                RaisePropertyChanged(() => Filter);
                UpdateAutocompete();
            }
        }

        public async void MarkerClick(string title)
        {
            if (_directions != null) {
                var direction = _directions.Where(d => d.Iata == title).FirstOrDefault();
                if (direction != null)
                    ShowFindTickets(direction);
            }
        }

        private void ShowFindTickets(Direction direction)
        {
            _navigationService.Navigate<FindTicketsViewModel, Direction>(direction);
        }

        private async void UpdateAutocompete()
        {
            _ = Task.Factory.StartNew(async delegate
              {
                  if (!_autocompleteRequestInProgress)
                  {
                      _autocompleteRequestInProgress = true;
                      await GetAutocomplete();
                      _autocompleteRequestInProgress = false;
                  }
              });
        }

        private async Task GetAutocomplete()
        {
            try
            {
                if (Filter.Length > 0)
                {
                    var response = await _travelPayoutsApi.GetPlaces(Filter);
                    AirportsAutocomplete = new MvxObservableCollection<AutocompleteIataItem>(response.Select(i => new AutocompleteIataItem(i)));
                }
                else
                {
                    AirportsAutocomplete.Clear();
                }
            }catch(Exception e)
            {
                ToString();
            }
        }

        public async void AutocompleteSelected(AutocompleteIataItem item)
        {
            await Search(item.Code);
        }
        public void AirportClick(IataItem item)
        {
            ShowFindTickets(item.Direction);
        }
        public async Task Search(string code = null)
        {
            AirportsAutocomplete.Clear();
            EmptyVisibility = false;
            Airports.Clear();
            SearchProgressVisibility = true;
            try
            {
                SupportedDirectionsResponse response = null;
                if (!string.IsNullOrEmpty(code))
                    response = await _aviasalesApi.GetSupportedDirections(code);
                else if (!string.IsNullOrEmpty(Filter))
                    response = await _aviasalesApi.GetSupportedDirections(Filter);
                Airports = new MvxObservableCollection<IataItem>(response.Directions.Select(d => new IataItem(d)));

                _directions = response.Directions;
                var markers = response.Directions.Where(d => d.Coordinates[0].HasValue && d.Coordinates[1].HasValue).Select(w => new Marker(w.Iata, w.Coordinates));
                _mvxMessenger.Publish(new CreateMarkersMessage(this, markers));
            }
            catch (Exception e)
            {
                ToString();
                EmptyVisibility = true;
            }
            SearchProgressVisibility = false;
        }

        private MvxObservableCollection<IataItem> _Airports = new MvxObservableCollection<IataItem>();
        public MvxObservableCollection<IataItem> Airports
        {
            get { return _Airports; }
            set
            {
                _Airports = value;
                RaisePropertyChanged(() => Airports);
            }
        }

        private Direction[] _directions;
        private bool _SearchProgressVisibility = false;

        public bool SearchProgressVisibility
        {
            get { return _SearchProgressVisibility; }
            set
            {
                _SearchProgressVisibility = value;
                RaisePropertyChanged(() => SearchProgressVisibility);
            }
        }

        private string _EmptyText = strings.empty_text;

        public string EmptyText
        {
            get { return _EmptyText; }
            set
            {
                _EmptyText = value;
                RaisePropertyChanged(() => EmptyText);
            }
        }

        private bool _EmptyVisibility = true;

        public bool EmptyVisibility
        {
            get { return _EmptyVisibility; }
            set
            {
                _EmptyVisibility = value;
                RaisePropertyChanged(() => EmptyVisibility);
            }
        } 
    }
}
