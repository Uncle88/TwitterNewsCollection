using System;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;

namespace TwitterNewsCollectionAndroid.Services.AuthService
{
    public class AndroidAuthenticationService : IAuthenticationService
    {
        public event EventHandler<TwitterEventArgs> ResponseFeedsCompleted;

        public void LoginToTwitter()
        {
            
        }
    }
}
