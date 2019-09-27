// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace OnTheFly.iOS.Views
{
    [Register ("FindAirportView")]
    partial class FindAirportView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar appBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        OnTheFly.iOS.WrapContentTableView autocompleteTabView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView destinationsTabView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel emptyText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView mapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView searchProgress { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (appBar != null) {
                appBar.Dispose ();
                appBar = null;
            }

            if (autocompleteTabView != null) {
                autocompleteTabView.Dispose ();
                autocompleteTabView = null;
            }

            if (destinationsTabView != null) {
                destinationsTabView.Dispose ();
                destinationsTabView = null;
            }

            if (destinationsTabView != null) {
                destinationsTabView.Dispose ();
                destinationsTabView = null;
            }

            if (emptyText != null) {
                emptyText.Dispose ();
                emptyText = null;
            }

            if (mapView != null) {
                mapView.Dispose ();
                mapView = null;
            }

            if (searchProgress != null) {
                searchProgress.Dispose ();
                searchProgress = null;
            }
        }
    }
}