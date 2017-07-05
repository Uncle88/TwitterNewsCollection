using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using TwitterNewsCollection.Services.PlatformUI;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        public ListViewModel(IAuthenticationService authS, INativeUI ui)
        {
            authS.ResponseFeedsCompleted += OnResponseFeedsCompleted;
            var oauth = authS.LoginToTwitter();
            ui.GetNativeUI(oauth);
        }

		public List<RetwittedItem> TwitterFeeds { get; private set; }

        private void OnResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            TwitterFeeds = e.TwitterObjects;
            RaisePropertyChanged(nameof(TwitterFeeds));
        }
    }
}
