using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Reflection;
using MvvmCross.Platform;
using TwitterNewsCollection.Authentication;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.ViewModels
{
    public class AuthViewModel : MvxViewModel
    {
        private readonly IAuthenticationService _authServ;
        private readonly IMvxNavigationService _navigationService;

        public AuthViewModel(IAuthenticationService authServ, IMvxNavigationService navigationService)
        {
            _authServ = authServ;
            _authServ.LoginToTwitter();
            _navigationService = navigationService;
        }

        public async Task PassParamToListViewModel()
        {
            await _navigationService.Navigate<ListViewModel, TwitterTricks>(new TwitterTricks());
            return;
        }
    }
}