using System.Diagnostics.Contracts;
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollectionAndroid.Services.AuthService;

namespace TwitterNewsCollectionAndroid.Views
{
[Activity(Label = "Twitter", MainLauncher = true)]
	public class TwitterCollectionView : MvxActivity
	{
        MvxRecyclerView List;

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

			SetContentView(Resource.Layout.CollectionView);

			List = this.FindViewById<MvxRecyclerView>(Resource.Id.myView);
			List.ItemTemplateId = Resource.Layout.listItemTwitterFeeds;

			var authServ = new AndroidAuthenticationService();
            authServ.ResponseFeedsCompleted += authAndroidResponseFeedsCompleted;
			authServ.LoginToTwitter();
        }

        void authAndroidResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            this.RunOnUiThread(()=>
            {
				List.ItemsSource = e.TwitterObjects;            
            });
        }
    }
}

