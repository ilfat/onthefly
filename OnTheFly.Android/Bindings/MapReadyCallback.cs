using Android.Gms.Maps;

namespace OnTheFly.Android.Bindings
{
    public class MapReadyCallback : Java.Lang.Object, IOnMapReadyCallback
    {
        public GoogleMap Map { get; private set; }
        
        public void OnMapReady(GoogleMap googleMap)
        {
            Map = googleMap;
            MapReady?.Invoke(googleMap);
        }

        public delegate void MapReadyEventHandler(GoogleMap googleMap);
        public MapReadyEventHandler MapReady;
    }
}