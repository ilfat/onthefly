using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using OnTheFly.Core.ViewModels;
using UIKit;

namespace OnTheFly.iOS.Views.FindAirport
{
    public partial class IataCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("IataCell");
        public static readonly UINib Nib;

        static IataCell()
        {
            Nib = UINib.FromName("IataCell", NSBundle.MainBundle);
        }

        protected IataCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                this.CreateBindingSet<IataCell, IataItem>().Bind(contentText).To(vm => vm.Content).Apply();
            });
        }        
    }
}
