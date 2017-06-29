using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using TwitterNewsCollection;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollectionAndroid.Services.AuthService;

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
			Mvx.RegisterSingleton<IAuthenticationService>(new AndroidAuthenticationService());
			base.InitializePlatformServices();
		}
	}
}