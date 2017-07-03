using Android.App;
using Android.OS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
using TwitterNewsCollection.ViewModels;

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

			List = this.FindViewById<MvxRecyclerView>(Resource.Id.myView);
			List.ItemTemplateId = Resource.Layout.listItemTwitterFeeds;
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.CollectionView);

            var set = this.CreateBindingSet<TwitterCollectionView, ListViewModel>();
        }
    }
}