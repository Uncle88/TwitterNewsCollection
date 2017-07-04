using System;
using System.Linq;
using Newtonsoft.Json;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using Xamarin.Auth;

namespace TwitterNewsCollection.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;

		private readonly Uri urlRequest = new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json");
		private const string methodRequest = "GET";
		private const string errorResponseMessage = "response not received";
		private const string errorAuthMessage = "Not Authenticated";

        public OAuth1Authenticator LoginToTwitter()
		{
			var auth = new OAuth1Authenticator(
				Constants.Consumer_KEY,
				Constants.Consumer_SECRET,
				new Uri(Constants.TWITTER_REQTOKEN_URL),
				new Uri(Constants.TWITTER_AUTH),
				new Uri(Constants.TWITTER_ACCESSTOKEN_URL),
				new Uri(Constants.TWITTER_CALLBACK_URL));

			auth.Completed += OnAuthCompleted;

            return auth;
        }

			private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
			{
				if (eventArgs.IsAuthenticated)
				{
					var request = new OAuth1Request(methodRequest, urlRequest, null, eventArgs.Account);
					var response = await request.GetResponseAsync();
					if (response != null)
					{
						string _data = response.GetResponseText();
						var _newsResponce = (RetwittedItem[])JsonConvert.DeserializeObject(_data, typeof(RetwittedItem[]));
						TwitterEventArgs twEventArgs = new TwitterEventArgs(_newsResponce.ToList());
						ResponseFeedsCompleted?.Invoke(this, twEventArgs);
					}
					else
					{
					//Toast.MakeText(Application.Context, errorResponseMessage, ToastLength.Long).Show();  ---  replace for service
				    }
				}
				else
				{
					//Toast.MakeText(Application.Context, errorAuthMessage, ToastLength.Long).Show();   ---  replace for service
				}
			}
        }
    }
