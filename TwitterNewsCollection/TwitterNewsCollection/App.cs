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
            Mvx.RegisterSingleton<IAuthenticationService>(new AuthenticationService(Mvx.Resolve<IErrorMessageService>(),Mvx.Resolve<INativeUIService>()));

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterAppStart<ViewModels.ListViewModel>();
        }
    }
}