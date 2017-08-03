
using System;

namespace TwitterNewsCollection.Constants
{
    public class TwitterConstants
    {
        public static readonly string Consumer_KEY = "ZYAaM25koQg2Jdkm1CrSPvCl4";
        public static readonly string Consumer_SECRET = "lgc4bXD3u7AYe9xgwbtgkTincbJR9Ed4oSTJ9H09bMf4RPa9FB";
		public static readonly string TWITTER_REQTOKEN_URL = "https://api.twitter.com/oauth/request_token";
        public static readonly string TWITTER_AUTH = "https://api.twitter.com/oauth/authorize";
        public static readonly string TWITTER_ACCESSTOKEN_URL = "https://api.twitter.com/oauth/access_token";
        public static readonly string TWITTER_CALLBACK_URL = "https://mobile.twitter.com/home";
        public static readonly string TWITTER_GRAPH_URL = "https://api.twitter.com/1.1/account/verify_credentials.json";
        public static readonly string TWITTER_ACCESS_TOKEN = "https://api.twitter.com/oauth2/token";
        public static readonly string TWITTER_ACCESS_TOKEN_Secret = "4j99v98ZQugQCQZfitpjBtaqVPcvcM7fwoaqntsJM75MR";

		public const string MethodRequest = "GET";
        public static readonly Uri urlRequest = new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json");

		public const string ErrorTitle = "Error";
		public const string ButtonText = "OK";
	}
}
