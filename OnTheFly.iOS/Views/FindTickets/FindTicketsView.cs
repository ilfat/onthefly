using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using OnTheFly.Core.ViewModels.FindTickets;
using OnTheFly.iOS.Views.FindTickets;
using System;
using UIKit;

namespace OnTheFly.iOS
{
    public partial class FindTicketsView : MvxViewController<FindTicketsViewModel>
    {
        public FindTicketsView (IntPtr handle) : base (handle)
        {
        }

        public FindTicketsView() : base("FindTicketsView", null)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CreateBindings();

            SetupNavigationBar();

            
            SetupTicketsTabView();
        }

        private void SetupTicketsTabView()
        {
            var source = new MvxSimpleTableViewSource(ticketsTabView, TicketViewCell.Key, TicketViewCell.Key);
            ticketsTabView.RowHeight = 60;
            ticketsTabView.Source = source;
            var bindingSet = this.CreateBindingSet<FindTicketsView, FindTicketsViewModel>();
            bindingSet.Bind(source).To(vm => vm.Tickets);
            bindingSet.Apply();
            ticketsTabView.ReloadData();
        }

        private void SetupNavigationBar()
        {
            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0x21, 0x96, 0xF3);
            NavigationController.NavigationBar.TintColor = UIColor.White;
            NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
            NavigationController.NavigationBar.Translucent = false;
            this.CreateBinding(NavigationController.NavigationBar.TopItem.BackBarButtonItem).For(b => b.Title).To<FindTicketsViewModel>(vm => vm.BackButtonTitle).Apply();
        }

        private void CreateBindings()
        {
            var bindingSet = this.CreateBindingSet<FindTicketsView, FindTicketsViewModel>();
            bindingSet.Bind(this).For(v => v.Title).To(vm => vm.Title);
            bindingSet.Bind(cityText).To(vm => vm.City);
            bindingSet.Bind(iataText).To(vm => vm.Title);
            bindingSet.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = false;            
        }
    }
}