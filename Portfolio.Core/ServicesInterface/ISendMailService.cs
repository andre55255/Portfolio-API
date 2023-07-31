using Portfolio.Communication.ViewObjects.Emails;

namespace Portfolio.Core.ServicesInterface
{
    public interface ISendMailService
    {
        public Task SendMailForgotPasswordAsync(EmailDataForgotPassVO data);
    }
}
