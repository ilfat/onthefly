using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using OnTheFly.Core.ViewModels;
using System;
using UIKit;

namespace OnTheFly.iOS.Views
{
    public partial class AutocompleteIataCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("AutocompleteIataCell");
        public static readonly UINib Nib;
        static AutocompleteIataCell()
        {
            Nib = UINib.FromName("AutocompleteIataCell", NSBundle.MainBundle);
        }

        public AutocompleteIataCell(IntPtr handle): base(handle)
        {
            this.DelayBind(() =>
            {
                this.CreateBindingSet<AutocompleteIataCell, AutocompleteIataItem>()
                    .Bind(iata).To(vm => vm.Content)
                    .Apply();
            });
        }
    }
}