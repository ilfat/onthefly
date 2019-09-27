// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace OnTheFly.iOS.Views
{
    [Register ("AutocompleteIataCell")]
    partial class AutocompleteIataCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel iata { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView searchImg { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (iata != null) {
                iata.Dispose ();
                iata = null;
            }

            if (searchImg != null) {
                searchImg.Dispose ();
                searchImg = null;
            }
        }
    }
}