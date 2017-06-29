using System.Diagnostics.Contracts;
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.ViewModels;
using TwitterNewsCollectionAndroid.Services.AuthService;

namespace TwitterNewsCollectionAndroid.Views
{
[Activity(Label = "Twitter", MainLauncher = true)]
	public class TwitterCollectionView : MvxActivity
	{
        MvxRecyclerView List;

		public new ListViewModel ViewModel
		{
			get { return (ListViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			SetContentView(Resource.Layout.CollectionView);

			List = this.FindViewById<MvxRecyclerView>(Resource.Id.myView);
			List.ItemTemplateId = Resource.Layout.listItemTwitterFeeds;

			//var authServ = new AndroidAuthenticationService();
   //         authServ.ResponseFeedsCompleted += authAndroidResponseFeedsCompleted;
			//authServ.LoginToTwitter();
        }

        void authAndroidResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            this.RunOnUiThread(()=>
            {
				List.ItemsSource = e.TwitterObjects;            
            });
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.CollectionView);

            var set = this.CreateBindingSet<TwitterCollectionView, ListViewModel>();
        }
    }
}