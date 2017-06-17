using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Reflection;
using MvvmCross.Platform;
using TwitterNewsCollection.Authentication;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using TwitterNewsCollection.Models;
using TwitterNewsCollection.Helpers;
using System.Collections.Generic;

namespace TwitterNewsCollection.ViewModels
{
    public class AuthViewModel : MvxViewModel
    {
        private readonly IAuthenticationService _authServ;
        private readonly IMvxNavigationService _navigationService;

        public AuthViewModel(IAuthenticationService authServ, IMvxNavigationService navigationService)
        {
            _authServ = authServ;
            _authServ.ResponseFeedsCompleted += _authServ_ResponseFeedsCompleted;
            _authServ.LoginToTwitter();
            _navigationService = navigationService;
        }

        void _authServ_ResponseFeedsCompleted(object sender, TwitterEventArgs e)
        {
            var a = e.TwitterObjects;
            _navigationService.Navigate<ListViewModel, List<RootObject>>(e.TwitterObjects);
        }
    }
}