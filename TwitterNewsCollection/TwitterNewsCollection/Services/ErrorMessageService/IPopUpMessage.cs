using System;
namespace TwitterNewsCollection.Services.ErrorMessageService
{
    public interface IPopUpMessage
    {
        void GetToastNotAuth();
        void GetToastNotResponse();
    }
}
