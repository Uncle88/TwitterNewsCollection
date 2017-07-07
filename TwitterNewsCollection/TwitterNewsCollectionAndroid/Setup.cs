using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using TwitterNewsCollection;
using TwitterNewsCollection.Services.ErrorMessageService;
using TwitterNewsCollection.Services.PlatformUI;
using TwitterNewsCollectionAndroid.Services.AuthService;
using TwitterNewsCollectionAndroid.Services.ErrorMessageService;

namespace TwitterNewsCollectionAndroid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
        : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

		protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
		{
			typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
		};

		protected override void InitializePlatformServices()
		{
			Mvx.RegisterSingleton<INativeUIService>(new AndroidNativeUIService());
			Mvx.RegisterSingleton<IErrorMessageService>(new AndroidErrorMessageService());
			base.InitializePlatformServices();
		}
	}
}