using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        public ListViewModel(IAuthenticationService authServ)
        {
            authServ.ResponseFeedsCompleted += OnResponseFeedsCompleted;
			authServ.LoginToTwitter();
        }

		public List<TwitterNewsResponse> TwitterFeeds { get; private set; }

        private void OnResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            TwitterFeeds = e.TwitterObjects;
            RaisePropertyChanged(nameof(TwitterFeeds));
        }
    }
}
