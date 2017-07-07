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
        public ListViewModel(IAuthenticationService authService, INativeUIService uiService)
        {
            authService.ResponseFeedsCompleted += OnResponseFeedsCompleted;
            var oauth = authService.LoginToTwitter();
            uiService.PlatformNativeUI(oauth);
        }

		public List<RetwittedItem> TwitterFeeds { get; private set; }

        private void OnResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            TwitterFeeds = e.TwitterObjects;
            RaisePropertyChanged(nameof(TwitterFeeds));
        }
    }
}
