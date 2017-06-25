using System;
using Android.App;
using MvvmCross.Droid.Views;

namespace TwitterNewsCollectionAndroid.Views
{
[Activity(Label = "Twitter", MainLauncher = true)]
	public class TwitterCollectionView : MvxActivity
	{
		protected override void OnViewModelSet()
		{
            SetContentView(Resource.Layout.CollectionView);
		}
	}
}

