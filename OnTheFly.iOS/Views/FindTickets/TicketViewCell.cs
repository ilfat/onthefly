using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using OnTheFly.Core.ViewModels.FindTickets;
using UIKit;

namespace OnTheFly.iOS.Views.FindTickets
{
    public partial class TicketViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TicketViewCell");
        public static readonly UINib Nib;

        static TicketViewCell()
        {
            Nib = UINib.FromName("TicketViewCell", NSBundle.MainBundle);
        }

        protected TicketViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<TicketViewCell, TicketItem>();
                bindingSet.Bind(cityText).To(vm => vm.City);
                bindingSet.Bind(departText).To(vm => vm.Depart);
                bindingSet.Bind(returnText).To(vm => vm.Return);
                bindingSet.Bind(costText).To(vm => vm.Cost);
                bindingSet.Apply();
            });
        }
    }
}
