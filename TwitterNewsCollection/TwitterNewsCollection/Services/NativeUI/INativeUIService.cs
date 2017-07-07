using Xamarin.Auth;

namespace TwitterNewsCollection.Services.PlatformUI
{
    public interface INativeUIService
    {
        void RejectView();
        void GetNativeUI(OAuth1Authenticator auth);//rename GetNativeUI
	}
}
