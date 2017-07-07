using System;
using TwitterNewsCollection.Helpers;
using Xamarin.Auth;

namespace TwitterNewsCollection.Authentication
{
    public interface IAuthenticationService
    {
        OAuth1Authenticator LoginToTwitter();
        event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;
    }
}
