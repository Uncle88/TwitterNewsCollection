using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Services.Authentication;
using TwitterNewsCollection.Services.ErrorMessageService;

namespace TwitterNewsCollection
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var popup = Mvx.Resolve<IPopUpMessage>();
            Mvx.RegisterSingleton<IAuthenticationService>(new AuthenticationService(popup));

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<ViewModels.ListViewModel>();
        }
    }
}