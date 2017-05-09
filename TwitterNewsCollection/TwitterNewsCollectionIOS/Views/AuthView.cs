using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwitterNewsCollection.ViewModels;
using UIKit;

namespace TwitterNewsCollectionIOS.Views
{
    public partial class AuthView : MvxViewController
    {
        public new AuthViewModel ViewModel
        {
            get { return (AuthViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public AuthView() : base("AuthView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.CreateBindingSet<AuthView, AuthViewModel>();
            this.CreateBinding(authButton).To((AuthViewModel vm) => vm.AuthCommand).Apply();
            authButton.TintColor = UIColor.Red;
            authButton.BackgroundColor = UIColor.Cyan;
            authButton.Layer.CornerRadius = 30;
        }
    }
}
