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
        public RootObject obj;

        public AuthViewModel(IAuthenticationService authServ, IMvxNavigationService navigationService)
        {
            _authServ = authServ;
            _authServ.LoginToTwitter();
            _navigationService = navigationService;
        }

        void Initialize (RootObject _rootObj)
        {
            obj = _rootObj;
        }

        public override void Appearing()//Task PassParamToListViewModel()
        {
            _navigationService.Navigate<ListViewModel, RootObject>(obj);
            ShowViewModel<ListViewModel>();
            //return;
        }
    }
}