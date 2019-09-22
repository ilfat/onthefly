using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using OnTheFly.Core.Api;
using OnTheFly.Core.ViewModels;
using System.Net.Http;

namespace OnTheFly.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterSingleton<IAviasalesApi>(new AviasalesApi(new HttpClient()));
            Mvx.IoCProvider.RegisterSingleton<ITravelPayoutsApi>(new TravelPayoutsApi(new HttpClient()));
            CreatableTypes()
                   .EndingWith("Service")
                   .AsInterfaces()
                   .RegisterAsLazySingleton();
            RegisterAppStart<FindAirportViewModel>();
        }
    }
}
