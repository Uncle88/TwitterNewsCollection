using System;
using TwitterNewsCollection.Services.ErrorMessageService;
using UIKit;

namespace TwitterNewsCollectionIOS.Services.IosErrorMessageService
{
    public class iOSErrorMessageService : IErrorMessageService
    {
        private const string ErrorTitle = "Error";
        private const string ButtonText = "OK";

        public void ShowErrorMessage(string message)
        {
			UIAlertView alert = new UIAlertView();
			alert.Title = ErrorTitle;
			alert.Message = message;
			alert.AddButton(ButtonText);
			alert.Show();
			return;
        }
    }
}
