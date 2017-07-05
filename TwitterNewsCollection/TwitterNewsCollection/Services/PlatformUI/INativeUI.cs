using System;
using Xamarin.Auth;

namespace TwitterNewsCollection.Services.PlatformUI
{
    public interface INativeUI
    {
        void RejectView();
        void GetNativeUI(OAuth1Authenticator auth);
    }
}
