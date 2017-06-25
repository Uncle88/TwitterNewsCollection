using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
		private readonly IAuthenticationService _authServ;

        public ListViewModel(IAuthenticationService authServ)
        {
			_authServ = authServ;
            _authServ.ResponseFeedsCompleted += OnResponseFeedsCompleted;
			_authServ.LoginToTwitter();
        }

        private void OnResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            TwitterFeeds = e.TwitterObjects;
            RaisePropertyChanged(nameof(TwitterFeeds));
        }

        public List<TwitterNewsResponse> TwitterFeeds { get; private set; }
    }
}
