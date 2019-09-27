// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace OnTheFly.iOS
{
    [Register ("FindTicketsView")]
    partial class FindTicketsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cityText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel iataText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ticketsTabView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cityText != null) {
                cityText.Dispose ();
                cityText = null;
            }

            if (iataText != null) {
                iataText.Dispose ();
                iataText = null;
            }

            if (ticketsTabView != null) {
                ticketsTabView.Dispose ();
                ticketsTabView = null;
            }
        }
    }
}