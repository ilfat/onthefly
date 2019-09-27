using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;
using OnTheFly.Core;

namespace OnTheFly.Android
{
    [Activity(
        Theme = "@style/SplashTheme",
        Label = "@string/app_name",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity<Setup, App>
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        { }
    }
}