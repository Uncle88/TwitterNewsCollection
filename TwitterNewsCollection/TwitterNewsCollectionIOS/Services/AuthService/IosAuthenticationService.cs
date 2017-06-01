using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitterNewsCollection.Authentication;
using UIKit;
using Xamarin.Auth;
using TwitterNewsCollection.Models;
using TwitterNewsCollection;
using TwitterNewsCollection.Helpers;

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

            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    //"https://api.twitter.com/1.1/favorites/list.json"---https://api.twitter.com/1.1/account/verify_credentials.json
                    //https://api.twitter.com/1.1/statuses/home_timeline.json
                    //https://api.twitter.com/1.1/statuses/retweets/857636306666520577.json
                    var request = new OAuth1Request("GET", new Uri(/*"https://api.twitter.com/1.1/statuses/retweets/509457288717819904.json"*/"https://api.twitter.com/1.1/statuses/user_timeline.json"), null, eventArgs.Account, false);
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
												//GetTwitterObjects(t);
                                                   OnEventArgs(GetTwitterObjects(t));
                                                //ResponseFeedsCompleted?.Invoke(this, new EventArgs());
                                            }
                                        });
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
            };

            var authView = (UIKit.UIViewController)auth.GetUI();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            vc.PresentViewController(authView, true, null);
        }

        private void OnEventArgs(string someData)
        {
            TwitterEventArgs twEventArgs = new TwitterEventArgs();
			//if (ResponseFeedsCompleted != null)
			{
                twEventArgs._rootObj = (System.Collections.Generic.List<TwitterNewsCollection.Models.RootObject>)JsonConvert.DeserializeObject<object>(someData); ;
				ResponseFeedsCompleted?.Invoke(this, twEventArgs);
			}
        }

        string GetTwitterObjects(Task<Response> t)
        {
            string _data = t.Result.GetResponseText();
            return _data;
            //try
            //{
            //    var obj = JsonConvert.DeserializeObject<object>(_data);
            //    return obj;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("===");
            //    return null;
            //}
        }
    }
}

