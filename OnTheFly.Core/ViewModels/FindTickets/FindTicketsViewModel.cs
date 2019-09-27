using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using OnTheFly.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnTheFly.Core.ViewModels.FindTickets
{
    public class FindTicketsViewModel : MvxViewModel<Direction>
    {
        public FindTicketsViewModel(IAviasalesApi aviasalesApi, IMvxNavigationService navigationService)
        {
            _aviasalesApi = aviasalesApi;
            _navigationService = navigationService;
        }
        public override void Prepare(Direction direction)
        {
            Title = direction.Iata;
            City = direction.Name;
        }
        public override void ViewCreated()
        {
            base.ViewCreated();
            FindTickets();
        }

        public void Close()
        {
            _navigationService.Close(this);
        }

        private async void FindTickets()
        {
            FindPriceProgressVisibility = true;
            try
            {
                var response = await _aviasalesApi.GetPrices(Title);
                Tickets = new MvxObservableCollection<TicketItem>(response.Where(r => r.Actual).Select(a => new TicketItem(a)));
            }
            catch(Exception e)
            {

            }
            FindPriceProgressVisibility = false;
        }

        private string _Title = "";

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        private string _City = "";

        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                RaisePropertyChanged(() => City);
            }
        }


        private bool _FindPriceProgressVisibility = false;
        private IAviasalesApi _aviasalesApi;
        private IMvxNavigationService _navigationService;

        public bool FindPriceProgressVisibility
        {
            get { return _FindPriceProgressVisibility; }
            set
            {
                _FindPriceProgressVisibility = value;
                RaisePropertyChanged(() => FindPriceProgressVisibility);
            }
        }

        private MvxObservableCollection<TicketItem> _Tickets = new MvxObservableCollection<TicketItem>();

        public MvxObservableCollection<TicketItem> Tickets
        {
            get { return _Tickets; }
            set
            {
                _Tickets = value;
                RaisePropertyChanged(() => Tickets);
            }
        }

        public string BackButtonTitle => strings.back;
    }
}
