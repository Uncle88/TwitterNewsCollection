using System;
using System.Linq;
using Newtonsoft.Json;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Constants;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using TwitterNewsCollection.Services.ErrorMessageService;
using TwitterNewsCollection.Services.PlatformUI;
using Xamarin.Auth;

namespace TwitterNewsCollection.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IErrorMessageService popUpMessageService;
        private INativeUIService nativeUIService;

        //TODO: try delete event and use method instead
        public event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;

        public AuthenticationService(IErrorMessageService popUpMes,INativeUIService natUIService )
        {
            popUpMessageService = popUpMes;
            nativeUIService = natUIService;
        }

        public OAuth1Authenticator LoginToTwitter()
        {
            var auth = new OAuth1Authenticator(
                TwitterConstants.Consumer_KEY,
                TwitterConstants.Consumer_SECRET,
                new Uri(TwitterConstants.TWITTER_REQTOKEN_URL),
                new Uri(TwitterConstants.TWITTER_AUTH),
                new Uri(TwitterConstants.TWITTER_ACCESSTOKEN_URL),
                new Uri(TwitterConstants.TWITTER_CALLBACK_URL));

            auth.Completed += OnAuthCompleted;

            return auth;
        }

        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            nativeUIService.RejectView();
            if (eventArgs.IsAuthenticated)
            {
                var request = new OAuth1Request(TwitterConstants.MethodRequest, TwitterConstants.urlRequest, null, eventArgs.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    var data = response.GetResponseText();
                    var newsResponce = (RetwittedItem[])JsonConvert.DeserializeObject(data, typeof(RetwittedItem[]));
                    var twEventArgs = new TwitterEventArgs(newsResponce.ToList());

                    ResponseFeedsCompleted?.Invoke(this, twEventArgs);
                }
                else
                {
                    popUpMessageService.ShowErrorMessage(ErrorMessages.ErrorResponseMessage);
                }
            }
            else
            {
                popUpMessageService.ShowErrorMessage(ErrorMessages.ErrorAuthMessage);
			}
        }
    }
}
