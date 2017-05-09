using System;
using TwitterNewsCollection.Authentication;
using UIKit;
using Xamarin.Auth;

namespace TwitterNewsCollectionIOS
{
    public class IosAuthenticationService : IAuthenticationService
    {
        public void LoginToTwitter()
        {
            var auth = new OAuth1Authenticator(
            consumerKey: "7xxNH3hQXahsT65rhaDItvL15", // For Twitter login, for configure refer http://www.c-sharpcorner.com/article/register-identity-provider-for-new-oauth-application/  
consumerSecret: "Ggu9DCwRt6QPTeFzEoAt5R5KHTZT3cuA0lCKgnhFZUidVMJJtf", // For Twitter login, for configure refer http://www.c-sharpcorner.com/article/register-identity-provider-for-new-oauth-application/  
requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), // These values do not need changing  
authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), // These values do not need changing  
accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"), // These values do not need changing  
                callbackUrl: new Uri("http://mobile.twitter.com"));//h Set this property to the location the user will be redirected too after successfully authenticating )


            //var auth = new OAuth1Authenticator(
            //Consumer_KEY,
            // Consumer_SECRET,
            //new Uri(TWITTER_REQTOKEN_URL),
            //new Uri(TWITTER_AUTH),
            //new Uri(TWITTER_ACCESSTOKEN_URL),
            //new Uri(TWITTER_CALLBACK_URL));

            auth.AllowCancel = true;

            UIViewController authView = (UIKit.UIViewController)auth.GetUI();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            vc.PresentViewController(authView, true, null);
            auth.Completed += (s, eventArgs) =>
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
                                                //object obj = JsonConvert.DeserializeObject<object>(_data);
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
        }
    }
}