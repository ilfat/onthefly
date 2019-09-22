using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using OnTheFly.Core.ViewModels.FindTickets;

namespace OnTheFly.Android.Views
{
    [Activity]
    public class FindTicketsView : MvxAppCompatActivity<FindTicketsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.find_tickets);
            FindViewById<Toolbar>(Resource.Id.toolbar).NavigationClick += (o, e) => ViewModel.Close();
        }
    }
}