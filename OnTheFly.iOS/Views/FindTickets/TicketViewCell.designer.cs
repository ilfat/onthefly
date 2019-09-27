// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace OnTheFly.iOS.Views.FindTickets
{
    [Register ("TicketViewCell")]
    partial class TicketViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cityText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel costText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel departText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel returnText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cityText != null) {
                cityText.Dispose ();
                cityText = null;
            }

            if (costText != null) {
                costText.Dispose ();
                costText = null;
            }

            if (departText != null) {
                departText.Dispose ();
                departText = null;
            }

            if (returnText != null) {
                returnText.Dispose ();
                returnText = null;
            }
        }
    }
}