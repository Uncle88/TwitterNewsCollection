using System;
using Android.App;
using Android.Widget;
using TwitterNewsCollection.Services.ErrorMessageService;

namespace TwitterNewsCollectionAndroid.Services.ErrorMessageService
{
    public class AndroidErrorMessageService : IErrorMessageService
    {
        public void ShowErrorMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}
