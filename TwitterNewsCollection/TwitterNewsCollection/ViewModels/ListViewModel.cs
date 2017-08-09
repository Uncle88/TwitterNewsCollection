using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Models;
using TwitterNewsCollection.Services.PlatformUI;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        private readonly IAuthenticationService _authService;
        private readonly INativeUIService _nativeUIService;

        public ListViewModel(IAuthenticationService authService, INativeUIService uiService)
        {
            _authService = authService;
            _nativeUIService = uiService;
        }

		public List<RetwittedItem> TwitterFeeds { get; private set; }

        public override async void Start()
        {
			var userAccount = await _authService.LoginToTwitter();

			if (userAccount == null)
			{
				return;
			}

			TwitterFeeds = await _authService.GetTwitterFeeds(userAccount);
			RaisePropertyChanged(nameof(TwitterFeeds));
		}
    }
}
