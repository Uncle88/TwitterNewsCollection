using System;
using TwitterNewsCollection.Services.PlatformUI;
using UIKit;
using Xamarin.Auth;

namespace TwitterNewsCollectionIOS
{
    public class IosNativeUIService : INativeUI
    {
        private UIViewController AuthView;
  
        public void GetNativeUI(OAuth1Authenticator auth)
        {
			AuthView = auth.GetUI();
			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;
			vc.PresentViewController(AuthView, true, null); 
        }

        public void RejectView()
        {
            AuthView.DismissViewController(true, null);
        }
    }
}
