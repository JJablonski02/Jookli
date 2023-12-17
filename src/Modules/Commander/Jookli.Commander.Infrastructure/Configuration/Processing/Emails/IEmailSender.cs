using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails
{
    public interface IEmailSender
    {
        string DefaultSenderAddress { get; }

        string DefaultSenderName { get; }

        void Send(Action<EmailMessageConfigurationBuilder> mailMessageBuild);

        Task SendAsync(Action<EmailMessageConfigurationBuilder> mailMessageBuild);

        void Send(MailMessage mailMessage);

        Task SendAsync(MailMessage mailMessage);

        void Send(string from, string to, string subject, string body, bool isBodyHtml);

        Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml);
    }
}
