using System;
using System.Linq;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using OnTheFly.Core.ViewModels;

namespace OnTheFly.Android.Bindings
{
    public class MapTargetBinding : MvxTargetBinding<MapFragment, List<Core.ViewModels.Marker>>
    {
        private GoogleMap _googleMap;
        private List<Core.ViewModels.Marker> _markers;

        public MapTargetBinding(MapFragment mapFragment) :base(mapFragment)
        {
            var mapReadyCallback = new MapReadyCallback();
            Target.GetMapAsync(mapReadyCallback);
            _googleMap = mapReadyCallback.Map;
            _googleMap.MarkerClick += MarkerClick;
        }

        private void MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            _markers.Where(m => m.Title == e.Marker.Title).FirstOrDefault()?.OnClick();
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        
        protected override void SetValue(List<Core.ViewModels.Marker> markers)
        {
            _markers = markers;
            foreach(var marker in markers)
            {
                var markerOptions = new MarkerOptions();
                markerOptions.SetPosition(new LatLng(marker.Lat, marker.Lng));
                markerOptions.SetTitle(marker.Title);
                _googleMap.AddMarker(markerOptions);
            }
        }
    }
}