using System;
using System.Linq;
using Android.App;
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
						var myObj = (TwitterNewsResponse[])JsonConvert.DeserializeObject(_data, typeof(TwitterNewsResponse[]));
						TwitterEventArgs twEventArgs = new TwitterEventArgs(myObj.ToList());
						ResponseFeedsCompleted?.Invoke(this, twEventArgs);
					}
					else
					{
						//UIAlertView alert = new UIAlertView();
						//alert.Message = "response not received";
						//alert.Show();
						//return;
					}
				}
				else
				{
					//UIAlertView alert = new UIAlertView()
					//{
					//	Title = "Error",
					//	Message = "Not Authenticated"
					//};
					//alert.AddButton("OK");
					//alert.Show();
					//return;
				}
			}
        }
    }
