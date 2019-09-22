using System;

namespace OnTheFly.Core.ViewModels
{
    public class Marker
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Title { get; set; }

        public void OnClick()
        {
            Click?.Invoke(this);
        }

        public delegate void ClickEventHandler(Marker marker);
        public ClickEventHandler Click;

        public Marker(string iata, double?[] coordinates)
        {
            this.Title = iata;
            this.Lat = coordinates[0].Value;
            this.Lng = coordinates[1].Value;
        }
    }
}
