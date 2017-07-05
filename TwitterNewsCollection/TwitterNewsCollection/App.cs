using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Services.Authentication;
using TwitterNewsCollection.Services.ErrorMessageService;
using TwitterNewsCollection.Services.PlatformUI;

namespace TwitterNewsCollection
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var natUIService = Mvx.Resolve<INativeUI>();
            var popUpMes = Mvx.Resolve<IPopUpMessage>();
            Mvx.RegisterSingleton<IAuthenticationService>(new AuthenticationService(popUpMes,natUIService));

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<ViewModels.ListViewModel>();
        }
    }
}