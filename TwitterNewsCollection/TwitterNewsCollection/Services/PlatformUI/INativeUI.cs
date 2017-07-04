using System;
using Xamarin.Auth;

namespace TwitterNewsCollection.Services.PlatformUI
{
    public interface INativeUI
    {
        void GetNativeUI(OAuth1Authenticator auth);
    }
}
