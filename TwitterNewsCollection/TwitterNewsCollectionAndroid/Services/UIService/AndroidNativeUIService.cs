using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Newtonsoft.Json;
using TwitterNewsCollection;
using TwitterNewsCollection.Authentication;
using TwitterNewsCollection.Helpers;
using TwitterNewsCollection.Models;
using TwitterNewsCollection.Services.PlatformUI;
using Xamarin.Auth;

namespace TwitterNewsCollectionAndroid.Services.AuthService
{
    public class AndroidNativeUIService : INativeUI
    {
		public void GetNativeUI(OAuth1Authenticator auth)
		{
			var intent = auth.GetUI(Application.Context);
			intent.AddFlags(Android.Content.ActivityFlags.NewTask);
			Application.Context.StartActivity(intent);
		}
    }
}
