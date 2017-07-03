using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Newtonsoft.Json;
using TwitterNewsCollection;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using Xamarin.Auth;

namespace TwitterNewsCollectionAndroid.Services.AuthService
{
    public class AndroidAuthenticationService : IAuthenticationService
    {
        public event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;

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

            var intent = auth.GetUI(Application.Context);
            intent.AddFlags(Android.Content.ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }

        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            if (eventArgs.IsAuthenticated)
            {
                var request = new OAuth1Request("GET", new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json"), null, eventArgs.Account);
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
                    Toast.MakeText(Application.Context, "response not received", ToastLength.Long).Show();
                }
            }
            else
            {
				Toast.MakeText(Application.Context, "Not Authenticated", ToastLength.Long).Show();
			}
        }
    }
}
