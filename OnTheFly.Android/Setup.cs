using Android.Gms.Maps;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using OnTheFly.Android.Bindings;
using OnTheFly.Core;

namespace OnTheFly.Android
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            //registry.RegisterCustomBindingFactory<MapFragment>("Markers", mapFragment => new MapTargetBinding(mapFragment));
        }
    }
}