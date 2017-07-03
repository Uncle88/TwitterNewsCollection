using System;
using System.Linq;
using System.Security.Policy;
using Newtonsoft.Json;
using TwitterNewsCollection;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using UIKit;
using Xamarin.Auth;

namespace TwitterNewsCollectionIOS
{
    public class IosAuthenticationService : IAuthenticationService
    {
        public event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;
        private UIViewController AuthView;
		private readonly Uri urlRequest = new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json");
        private const string methodRequest = "GET";
        private const string errorResponseMessage = "response not received";
        private const string errorAuthMessage = "Not Authenticated";
        private const string errorTitle = "Error";

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

            AuthView = auth.GetUI();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            vc.PresentViewController(AuthView, true, null);
        }

        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            AuthView.DismissViewController(true, null);
            if (eventArgs.IsAuthenticated)
            {
                var request = new OAuth1Request(methodRequest, urlRequest, null, eventArgs.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    string _data = response.GetResponseText();
                    var _newsResponce = (TwitterNewsResponse[])JsonConvert.DeserializeObject(_data, typeof(TwitterNewsResponse[]));
                    TwitterEventArgs twEventArgs = new TwitterEventArgs(_newsResponce.ToList());
                    ResponseFeedsCompleted?.Invoke(this, twEventArgs);
                }
                else
                {
                    UIAlertView alert = new UIAlertView();
                    alert.Message = errorResponseMessage;
                    alert.Show();
                    return;
                }
            }
            else
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = errorTitle,
                    Message = errorAuthMessage
                };
                alert.AddButton("OK");
                alert.Show();
                return;
            }
        }
    }
}
