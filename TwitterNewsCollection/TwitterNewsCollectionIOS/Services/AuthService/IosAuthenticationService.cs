using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitterNewsCollection.Authentication;
using UIKit;
using Xamarin.Auth;
using TwitterNewsCollection.Models;
using TwitterNewsCollection;
using TwitterNewsCollection.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace TwitterNewsCollectionIOS
{
    public class IosAuthenticationService : IAuthenticationService
    {
        public event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;
        private UIViewController AuthView;

        public void LoginToTwitter()
        {
            var auth = new OAuth1Authenticator(
                Constants.Consumer_KEY,
                Constants.Consumer_SECRET,
                new Uri(Constants.TWITTER_REQTOKEN_URL),
                new Uri(Constants.TWITTER_AUTH),
                new Uri(Constants.TWITTER_ACCESSTOKEN_URL),
                new Uri(Constants.TWITTER_CALLBACK_URL));

            auth.Completed += OnAuthCompleted;

            AuthView = (UIKit.UIViewController)auth.GetUI();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            vc.PresentViewController(AuthView, true, null);
        }

        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            AuthView.DismissViewController(true, null);
            if (eventArgs.IsAuthenticated)
            {
                var request = new OAuth1Request("GET", new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json"), null, eventArgs.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    string _data = response.GetResponseText();
                    var myObj = (TwitterNewsResponse[])JsonConvert.DeserializeObject(_data, typeof(TwitterNewsResponse[]));
                    TwitterEventArgs twEventArgs = new TwitterEventArgs(myObj.ToList());
                    ResponseFeedsCompleted?.Invoke(this, twEventArgs);
                }
                else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Error",
                        Message = "Not Authenticated"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                    return;
                }
            }
        }
    }
}
   