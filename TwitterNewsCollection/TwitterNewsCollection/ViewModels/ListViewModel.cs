using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using TwitterNewsCollection.Services.Authentication;
using TwitterNewsCollection.Services.PlatformUI;
using Xamarin.Auth;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        public ListViewModel(AuthenticationService authS, INativeUI ui, OAuth1Authenticator auth)
        {
            authS.ResponseFeedsCompleted += OnResponseFeedsCompleted;
            authS.LoginToTwitter();
            ui.GetNativeUI(auth);
        }

		public List<RetwittedItem> TwitterFeeds { get; private set; }

        private void OnResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            TwitterFeeds = e.TwitterObjects;
            RaisePropertyChanged(nameof(TwitterFeeds));
        }
    }
}
