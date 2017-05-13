using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitterNewsCollection.Authentication;
using UIKit;
using Xamarin.Auth;
using System.Net.Http.Headers;
using TwitterNewsCollection.Models;
using TwitterNewsCollection;

namespace TwitterNewsCollectionIOS
{
    public class IosAuthenticationService : Constants, IAuthenticationService
    {
        //public void LoginToTwitter()
        //{
        //    var auth = new OAuth1Authenticator(
        //        consumerKey: "ZYAaM25koQg2Jdkm1CrSPvCl4",
        //        consumerSecret: "lgc4bXD3u7AYe9xgwbtgkTincbJR9Ed4oSTJ9H09bMf4RPa9FB",
        //        requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
        //        authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
        //        accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
        //        callbackUrl: new Uri("http://app.home.com"));
        //    //var auth = new OAuth1Authenticator(
        //    //Consumer_KEY,
        //    // Consumer_SECRET,
        //    //new Uri(TWITTER_REQTOKEN_URL),
        //    //new Uri(TWITTER_AUTH),
        //    //new Uri(TWITTER_ACCESSTOKEN_URL),
        //    //new Uri(TWITTER_CALLBACK_URL));
        //requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
        //authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
        //accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
        //callbackUrl: new Uri("https://mobile.twitter.com/home")
        //    auth.AllowCancel = true;
        //    auth.Completed += (s, eventArgs) =>
        //    {
        //        if (eventArgs.IsAuthenticated)
        //        {
        //            var request = new OAuth1Request("GET", new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"), null, eventArgs.Account, false);
        //            request.GetResponseAsync().ContinueWith(t =>
        //                                {
        //                                    if (t.IsFaulted)
        //                                    {
        //                                        UIAlertView alert = new UIAlertView();
        //                                        alert.Message = t.Exception.InnerException.Message;
        //                                        alert.Show();
        //                                        return;
        //                                    }
        //                                    else
        //                                    {
        //                                        string _data = t.Result.GetResponseText();
        //                                        //object obj = JsonConvert.DeserializeObject<object>(_data);
        //                                    }
        //                                });
        //            return;
        //        }
        //        else
        //        {
        //            UIAlertView alert = new UIAlertView()
        //            {
        //                Title = "Error",
        //                Message = "Not Authenticated"
        //            };
        //            alert.AddButton("OK");
        //            alert.Show();
        //            return;
        //        }
        //    };
        //    var authView = (UIKit.UIViewController)auth.GetUI();
        //    var window = UIApplication.SharedApplication.KeyWindow;
        //    var vc = window.RootViewController;
        //    vc.PresentViewController(authView, true, null);
        //}
        public void LoginToTwitter()
        {
            var auth = new OAuth1Authenticator(
                Consumer_KEY,
                Consumer_SECRET,
                new Uri(TWITTER_REQTOKEN_URL),
                new Uri(TWITTER_AUTH),
                new Uri(TWITTER_ACCESSTOKEN_URL),
                new Uri(TWITTER_CALLBACK_URL));

            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    //"https://api.twitter.com/1.1/favorites/list.json"
                    //"https://api.twitter.com/1.1/followers/list.json"
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
                                                GetTwitterObjects(t);
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
            };

            var authView = (UIKit.UIViewController)auth.GetUI();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            vc.PresentViewController(authView, true, null);
        }

        RootObject GetTwitterObjects(Task<Response> t)
        {
            string _data = t.Result.GetResponseText();
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(_data);
            return obj;
        }
    }
}

