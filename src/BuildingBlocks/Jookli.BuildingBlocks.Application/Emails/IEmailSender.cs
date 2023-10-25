
namespace Jookli.BuildingBlocks.Application.Emails
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage email);
    }
}
