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
            var nativeUIService = Mvx.Resolve<INativeUIService>();
            var popUpMessageService = Mvx.Resolve<IPopUpMessageService>();
            Mvx.RegisterSingleton<IAuthenticationService>(new AuthenticationService(popUpMessageService,nativeUIService));

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterAppStart<ViewModels.ListViewModel>();
        }
    }
}