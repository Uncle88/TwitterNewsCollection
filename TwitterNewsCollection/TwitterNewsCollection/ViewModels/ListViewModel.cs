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
			_authServ.ResponseFeedsCompleted += _authServ_ResponseFeedsCompleted;
			_authServ.LoginToTwitter();
        }

        private void _authServ_ResponseFeedsCompleted(object sender, TwitterEventArgs e)//rename
        {
            TwitterFeeds = e.TwitterObjects;
            RaisePropertyChanged(nameof(TwitterFeeds));
        }

        public List<TwitterNewsResponse> TwitterFeeds { get; private set; }
    }
}
