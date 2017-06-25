using System;
using Android.App;
using MvvmCross.Droid.Views;
using TwitterNewsCollectionAndroid.Services.AuthService;

namespace TwitterNewsCollectionAndroid.Views
{
[Activity(Label = "Twitter", MainLauncher = true)]
	public class TwitterCollectionView : MvxActivity
	{
        protected override void OnViewModelSet()
		{
            SetContentView(Resource.Layout.CollectionView);
			var ser = new AndroidAuthenticationService();
			ser.ResponseFeedsCompleted += Ser_ResponseFeedsCompleted;
			ser.LoginToTwitter();
		}

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.CollectionView);
			var ser = new AndroidAuthenticationService();
			ser.ResponseFeedsCompleted += Ser_ResponseFeedsCompleted;
			ser.LoginToTwitter();
        }

        void Ser_ResponseFeedsCompleted(object sender, TwitterNewsCollection.Helpers.TwitterEventArgs e)
        {

        }
    }
}

