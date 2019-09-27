using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Plugin.Messenger;
using OnTheFly.Android.Bindings;
using OnTheFly.Core.ViewModels;

namespace OnTheFly.Android.Views
{
    [Activity]
    public class FindAirportView : MvxAppCompatActivity<FindAirportViewModel>
    {
        private GoogleMap _googleMap;
        private MvxSubscriptionToken _token;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.find_airport);
            var searchView = FindViewById<SearchView>(Resource.Id.search_view);
            searchView.QueryTextSubmit += delegate { ViewModel.Search(); };

            var mapFragment = SupportFragmentManager.FindFragmentById(Resource.Id.map);

            var mapReadyCallback = new MapReadyCallback();
            ((SupportMapFragment) mapFragment).GetMapAsync(mapReadyCallback);
            mapReadyCallback.MapReady += OnMapReady;
        }

        private void OnCreateMarkers(CreateMarkersMessage message)
        {
            _googleMap.Clear();
            foreach (var marker in message.Markers)
            {
                var markerOptions = new MarkerOptions();
                markerOptions.SetPosition(new LatLng(marker.Lng, marker.Lat));
                markerOptions.SetTitle(marker.Title);
                _googleMap.AddMarker(markerOptions);
            }
        }

        private void MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            ViewModel.MarkerClick(e.Marker.Title);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;
            _googleMap.MarkerClick += MarkerClick;
            _token = Mvx.IoCProvider.Resolve<IMvxMessenger>().Subscribe<CreateMarkersMessage>(OnCreateMarkers);
        }
    }
}