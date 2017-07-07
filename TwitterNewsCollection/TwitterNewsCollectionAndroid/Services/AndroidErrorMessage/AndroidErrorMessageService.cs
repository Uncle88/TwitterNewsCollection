using Android.App;
using Android.Widget;
using TwitterNewsCollection.Services.ErrorMessageService;

namespace TwitterNewsCollectionAndroid.Services.ErrorMessageService
{
    public class AndroidErrorMessageService : IErrorMessageService
    {
        private const string ErrorResponseMessage = "response not received";
        private const string ErrorAuthMessage = "Not Authenticated";

        public void ShowMessageNotAuth()
        {
			Toast.MakeText(Application.Context, ErrorAuthMessage, ToastLength.Long).Show();
        }

        public void ShowMessageNotResponse()
        {
			Toast.MakeText(Application.Context, ErrorResponseMessage, ToastLength.Long).Show();
        }
    }
}
