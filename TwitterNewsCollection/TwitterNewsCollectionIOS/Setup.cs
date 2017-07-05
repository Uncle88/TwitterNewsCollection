using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using TwitterNewsCollection.Services.ErrorMessageService;
using TwitterNewsCollection.Services.PlatformUI;
using TwitterNewsCollectionIOS.Services.IosErrorMessageService;
using UIKit;

namespace TwitterNewsCollectionIOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new TwitterNewsCollection.App();
        }

        protected override void InitializePlatformServices()
        {
			base.InitializePlatformServices();
            Mvx.RegisterSingleton<INativeUI>(new IosNativeUIService());
			Mvx.RegisterSingleton<IPopUpMessage>(new PopUpMessage());
        }
    }
}
