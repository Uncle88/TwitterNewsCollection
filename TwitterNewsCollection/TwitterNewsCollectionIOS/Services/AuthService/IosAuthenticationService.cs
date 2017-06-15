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

namespace TwitterNewsCollectionIOS
{
    public class IosAuthenticationService : IAuthenticationService
    {
        public event EventHandler ResponseFeedsCompleted;

        void IAuthenticationService.LoginToTwitter()
        {
            var auth = new OAuth1Authenticator(
                Constants.Consumer_KEY,
                Constants.Consumer_SECRET,
                new Uri(Constants.TWITTER_REQTOKEN_URL),
                new Uri(Constants.TWITTER_AUTH),
                new Uri(Constants.TWITTER_ACCESSTOKEN_URL),
                new Uri(Constants.TWITTER_CALLBACK_URL));

            auth.Completed += OnAuthCompleted;

            var authView = (UIKit.UIViewController)auth.GetUI();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            vc.PresentViewController(authView, true, null);
        }

            private void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
            {
			if (eventArgs.IsAuthenticated)
             {
				var request = new OAuth1Request("GET", new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"), null, eventArgs.Account, false);
				request.GetResponseAsync().ContinueWith(t =>
               {
					if (t.IsFaulted)
					{
						UIAlertView alert = new UIAlertView();
						alert.Message = t.Exception.InnerException.Message;
						alert.Show();
						return;
					}
				   else
                   {
						string _data = t.Result.GetResponseText();
					    object obj = JsonConvert.DeserializeObject<object>(_data);
				   }
				});
				return;
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
            


                //if (eventArgs.IsAuthenticated)
                //{
                //    //"https://api.twitter.com/1.1/favorites/list.json"---https://api.twitter.com/1.1/account/verify_credentials.json
                //    //https://api.twitter.com/1.1/statuses/home_timeline.json
                //    //https://api.twitter.com/1.1/statuses/retweets/857636306666520577.json
                //    var request = new OAuth1Request("GET", new Uri(/*"https://api.twitter.com/1.1/statuses/retweets/509457288717819904.json"*/"https://api.twitter.com/1.1/statuses/user_timeline.json"), null, eventArgs.Account, false);
                //    request.GetResponseAsync().ContinueWith( t => ResponceTwitterFeeds(t));                                
                //}

                //else
                //{
                //    UIAlertView alert = new UIAlertView()
                //    {
                //        Title = "Error",
                //        Message = "Not Authenticated"
                //    };
                //    alert.AddButton("OK");
                //    alert.Show();
                //    return;
                //}
            }

           public async Task ResponceTwitterFeeds(Task<Response> t)
            {
        if (t.IsFaulted)
        {
        	UIAlertView alert = new UIAlertView();
                      	alert.Message = t.Exception.InnerException.Message;
                       	alert.Show();
                    return ;
        }
        else
        {
        	var response = await t;
        	var responseStringData = response.GetResponseText();
        	OnEventArgs(responseStringData);
                    return ;
        }
        }

        private void OnEventArgs(string someData)
        {
            var twitObjects = (List<RootObject>)JsonConvert.DeserializeObject<object>(someData); ;
            TwitterEventArgs twEventArgs = new TwitterEventArgs(twitObjects);
            ResponseFeedsCompleted?.Invoke(this, twEventArgs);
        }
    }
}

