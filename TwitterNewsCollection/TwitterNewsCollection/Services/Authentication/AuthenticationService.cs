using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AuthenticationService(IErrorMessageService popUpMes,INativeUIService natUIService )
        {
            popUpMessageService = popUpMes;
            nativeUIService = natUIService;
        }

        public Task<Account> LoginToTwitter()
        {
            var tcs = new TaskCompletionSource<Account>();

            var auth = CreateAuthenticator();
            nativeUIService.PlatformNativeUI(auth);

            auth.Completed += (sender, authCompleteArgs) =>
            {
                Account userAccount = null;
                if (authCompleteArgs.IsAuthenticated)
                {
                    userAccount = authCompleteArgs.Account;
                }
                else
                {
                    popUpMessageService.ShowErrorMessage(ErrorMessages.ErrorAuthMessage);
                }

                tcs.SetResult(userAccount);
            };

            return tcs.Task;
        }

        public async Task<List<RetwittedItem>> GetTwitterFeeds(Account userAccount)
        {
			nativeUIService.RejectView();

            var request = new OAuth1Request(TwitterConstants.MethodRequest, new Uri(TwitterConstants.urlRequest), null, userAccount);
            var response = await request.GetResponseAsync();
            if (response != null)
            {
                var data = response.GetResponseText();
                var newsResponce = (RetwittedItem[])JsonConvert.DeserializeObject(data, typeof(RetwittedItem[]));
                return newsResponce.ToList();
            }
            else
            {
                popUpMessageService.ShowErrorMessage(ErrorMessages.ErrorResponseMessage);
                return null;
            }
        }

        private static OAuth1Authenticator CreateAuthenticator()
		{
			return new OAuth1Authenticator(
				TwitterConstants.Consumer_KEY,
				TwitterConstants.Consumer_SECRET,
				new Uri(TwitterConstants.TWITTER_REQTOKEN_URL),
				new Uri(TwitterConstants.TWITTER_AUTH),
				new Uri(TwitterConstants.TWITTER_ACCESSTOKEN_URL),
				new Uri(TwitterConstants.TWITTER_CALLBACK_URL));
		}
    }
}
