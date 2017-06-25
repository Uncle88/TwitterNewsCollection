using System;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using TwitterNewsCollection;

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
		}
}