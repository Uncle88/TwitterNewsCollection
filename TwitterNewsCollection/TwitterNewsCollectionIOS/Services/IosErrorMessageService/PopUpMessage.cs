using TwitterNewsCollection.Services.ErrorMessageService;
using UIKit;

namespace TwitterNewsCollectionIOS.Services.IosErrorMessageService
{
    public class PopUpMessage : IPopUpMessage
    {
		private const string errorResponseMessage = "response not received";
		private const string errorAuthMessage = "Not Authenticated";
		private const string errorTitle = "Error";
		private const string buttonText = "OK";

        public void ShowMessageNotAuth()
        {
			UIAlertView alert = new UIAlertView()
			{
				Title = errorTitle,
				Message = errorAuthMessage
			};
			alert.AddButton(buttonText);
			alert.Show();
			return;
        }

        public void ShowMessageNotResponse()
        {
			UIAlertView alert = new UIAlertView();
			alert.Message = errorResponseMessage;
			alert.Show();
			return;
        }
    }
}
