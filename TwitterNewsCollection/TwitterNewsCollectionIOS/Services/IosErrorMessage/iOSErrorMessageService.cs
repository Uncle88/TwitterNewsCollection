using TwitterNewsCollection.Services.ErrorMessageService;
using UIKit;

namespace TwitterNewsCollectionIOS.Services.IosErrorMessageService
{
    public class iOSErrorMessageService : IErrorMessageService
    {
        private const string ErrorResponseMessage = "response not received";
        private const string ErrorAuthMessage = "Not Authenticated";
        private const string ErrorTitle = "Error";
        private const string ButtonText = "OK";

        public void ShowMessageNotAuth()
        {
			UIAlertView alert = new UIAlertView()
			{
				Title = ErrorTitle,
				Message = ErrorAuthMessage
			};
			alert.AddButton(ButtonText);
			alert.Show();
			return;
        }

        public void ShowMessageNotResponse()
        {
			UIAlertView alert = new UIAlertView();
			alert.Message = ErrorResponseMessage;
			alert.Show();
			return;
        }
    }
}
