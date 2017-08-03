using System;
using TwitterNewsCollection.Constants;
using TwitterNewsCollection.Services.ErrorMessageService;
using UIKit;

namespace TwitterNewsCollectionIOS.Services.IosErrorMessageService
{
    public class iOSErrorMessageService : IErrorMessageService
    {
        public void ShowErrorMessage(string message)
        {
			UIAlertView alert = new UIAlertView();
			alert.Title = TwitterConstants.ErrorTitle;
			alert.Message = message;
			alert.AddButton(TwitterConstants.ButtonText);
			alert.Show();
			return;
        }
    }
}
