using Android.App;
using TwitterNewsCollection.Services.PlatformUI;
using Xamarin.Auth;

namespace TwitterNewsCollectionAndroid.Services.AuthService
{
    public class AndroidNativeUIService : INativeUIService
    {
		public void GetNativeUI(OAuth1Authenticator auth)
		{
			var intent = auth.GetUI(Application.Context);
			intent.AddFlags(Android.Content.ActivityFlags.NewTask);
			Application.Context.StartActivity(intent);
		}

        public void RejectView(){}
    }
}
