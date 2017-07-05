using Android.App;
using Android.Widget;
using TwitterNewsCollection.Services.ErrorMessageService;

namespace TwitterNewsCollectionAndroid.Services.ErrorMessageService
{
    public class PopUpMessage : IPopUpMessage
    {
        private const string errorResponseMessage = "response not received";
        private const string errorAuthMessage = "Not Authenticated";

        public void ShowMessageNotAuth()
        {
			Toast.MakeText(Application.Context, errorAuthMessage, ToastLength.Long).Show();
        }

        public void ShowMessageNotResponse()
        {
			Toast.MakeText(Application.Context, errorResponseMessage, ToastLength.Long).Show();
        }
    }
}
