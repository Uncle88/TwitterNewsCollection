using Xamarin.Auth;

namespace TwitterNewsCollection.Services.PlatformUI
{
    public interface INativeUIService
    {
        void RejectView();
        void PlatformNativeUI(OAuth1Authenticator auth);
	}
}
