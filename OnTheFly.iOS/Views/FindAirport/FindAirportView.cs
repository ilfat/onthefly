using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using OnTheFly.Core.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MapKit;
using OnTheFly.iOS.Views.FindAirport;
using System.Linq;
using MvvmCross.Platforms.Ios.Binding;

namespace OnTheFly.iOS.Views
{
    //[MvxRootPresentation(WrapInNavigationController = true)]
    public partial class FindAirportView : MvxViewController<FindAirportViewModel>
    {
        private UIBarButtonItem _searchButton;
        private UISearchBar _searchView;
        private MvxSubscriptionToken _token;

        public FindAirportView() : base ("FindAirportView", null)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupSearchBar();

            CreateBindings();

            SetupAutocomplete();

            SetupMap();

            SetupDestinations();

            searchProgress.StartAnimating();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBarHidden = true;
        }

        private void SetupDestinations()
        {
            var source = new MvxSimpleTableViewSource(destinationsTabView, IataCell.Key, IataCell.Key);
            destinationsTabView.RowHeight = 60;
            destinationsTabView.Source = source;
            var bindingSet = this.CreateBindingSet<FindAirportView, FindAirportViewModel>();
            bindingSet.Bind(source).To(vm => vm.Airports);
            bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.AirportSelectedCommand);
            bindingSet.Apply();
            destinationsTabView.ReloadData();
        }

        private void SetupMap()
        {
            _token = Mvx.IoCProvider.Resolve<IMvxMessenger>().Subscribe<CreateMarkersMessage>(OnCreateMarkers);
            mapView.DidDeselectAnnotationView += MarkerClick;
        }

        private void MarkerClick(object sender, MKAnnotationViewEventArgs e)
        {
            ViewModel.MarkerClick(e.View.Annotation.GetTitle());
        }

        private void OnCreateMarkers(CreateMarkersMessage message)
        {
            mapView.RemoveAnnotations(mapView.Annotations);
            foreach(var marker in message.Markers)
            {
                var annotation = new MKPointAnnotation();
                annotation.Coordinate = new CoreLocation.CLLocationCoordinate2D(marker.Lng, marker.Lat );
                annotation.Title = marker.Title;
                mapView.AddAnnotation(annotation);
            }
        }

        private void SetupAutocomplete()
        {
            var source = new MvxSimpleTableViewSource(autocompleteTabView, AutocompleteIataCell.Key, AutocompleteIataCell.Key);
            autocompleteTabView.RowHeight = 40;
            autocompleteTabView.Source = source;
            var bindinSet = this.CreateBindingSet<FindAirportView, FindAirportViewModel>();
            bindinSet.Bind(source).To(vm => vm.AirportsAutocomplete);
            bindinSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.AutocompleteSelectedCommand);
            bindinSet.Apply();
            autocompleteTabView.ReloadData();
        }

        private void CreateBindings()
        {
            var bindingSet = this.CreateBindingSet<FindAirportView, FindAirportViewModel>();
            bindingSet.Bind(appBar.TopItem).For(topItem => topItem.Title).To(vm => vm.Title);
            bindingSet.Bind(_searchView).For(s => s.Text).To(vm => vm.Filter);
            bindingSet.Bind(emptyText).For(e => e.BindVisible()).To(vm => vm.EmptyVisibility);
            bindingSet.Bind(emptyText).To(vm => vm.EmptyText);
            bindingSet.Bind(searchProgress).For(s => s.BindVisible()).To(vm => vm.SearchProgressVisibility);
            bindingSet.Bind(destinationsTabView).For(d => d.BindVisible()).To(vm => vm.AirportsVisibility);
            bindingSet.Apply();
        }

        private void SetupSearchBar()
        {
            _searchButton = new UIBarButtonItem(UIBarButtonSystemItem.Search, SearchClicked);
            _searchButton.TintColor = UIColor.White;
            _searchView = new UISearchBar();
            _searchView.ShowsCancelButton = true;
            _searchView.TintColor = UIColor.White;

            var textField = _searchView.Subviews[0].Subviews[1].Subviews.Where(s => s is UITextField).FirstOrDefault();
            if (textField != null)
            {
                textField.TintColor = UIColor.DarkTextColor;
            }
            _searchView.CancelButtonClicked += SearchViewCancelButtonClicked;
            _searchView.AutocapitalizationType = UITextAutocapitalizationType.AllCharacters;
            _searchView.BecomeFirstResponder();
            var gestureRecognizer
                = new UITapGestureRecognizer(() => View.EndEditing(true));
            gestureRecognizer.CancelsTouchesInView = false; //for iOS5
            View.AddGestureRecognizer(gestureRecognizer);
            _searchView.SearchButtonClicked += async delegate
            {
                View.EndEditing(true);
                await ViewModel.Search();
            };

            appBar.TopItem.RightBarButtonItem = _searchButton;            
        }

        private void SearchViewCancelButtonClicked(object sender, EventArgs e)
        {
            appBar.TopItem.TitleView = null;
            appBar.TopItem.RightBarButtonItem = _searchButton;
        }

        private void SearchClicked(object sender, EventArgs e)
        {
            appBar.TopItem.TitleView = _searchView;
            appBar.TopItem.RightBarButtonItem = null;
        }
    }
}