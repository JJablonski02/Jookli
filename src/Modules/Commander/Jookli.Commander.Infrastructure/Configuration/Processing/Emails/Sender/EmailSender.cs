using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Config;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Sender
{
    internal class EmailSender : IEmailSender
    {
        private readonly EmailSenderConfiguration _Config;

        private readonly SmtpClient _SmtpClient;

        public string DefaultSenderAddress => _Config.DefaultSenderAddress;

        public string DefaultSenderName => _Config.DefaultSenderDisplayName;

        public EmailSender(IOptions<EmailSenderConfiguration> config)
        {
            _Config = config.Value;
            _SmtpClient = new SmtpClient(_Config.Host, _Config.Port)
            {
                EnableSsl = _Config.EnableSSL,
                DeliveryFormat = _Config.DeliveryFormat,
                DeliveryMethod = _Config.DeliveryMethod,
                Timeout = _Config.Timeout,
                Credentials = new NetworkCredential(_Config.Uid, _Config.Password)
            };
        }

        public void Send(Action<EmailMessageConfigurationBuilder> mailMessageBuild)
        {
            EmailMessageConfigurationBuilder @new = EmailMessageConfigurationBuilder.New;
            mailMessageBuild(@new);
            internalSend(@new.Build());
        }

        public void Send(MailMessage mailMessage)
        {
            internalSend(mailMessage);
        }

        public void Send(string from, string to, string subject, string body, bool isBodyHtml)
        {
            MailMessage mailMessage = EmailMessageConfigurationBuilder.New.From(from, from).To(to).WithBody(body)
                .WithSubject(subject)
                .IsBodyHtml(isBodyHtml);
            internalSend(mailMessage);
        }

        public Task SendAsync(Action<EmailMessageConfigurationBuilder> mailMessageBuild)
        {
            EmailMessageConfigurationBuilder @new = EmailMessageConfigurationBuilder.New;
            mailMessageBuild(@new);
            return internalSendAsync(@new.Build());
        }

        public Task SendAsync(MailMessage mailMessage)
        {
            return internalSendAsync(mailMessage);
        }

        public Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml)
        {
            MailMessage mailMessage = EmailMessageConfigurationBuilder.New.From(from, from).To(to).WithBody(body)
                .WithSubject(subject)
                .IsBodyHtml(isBodyHtml);
            return internalSendAsync(mailMessage);
        }

        private void internalSend(MailMessage mailMessage)
        {
            _SmtpClient.Send(mailMessage);
            mailMessage.Dispose();
        }

        private Task internalSendAsync(MailMessage mailMessage)
        {
            return _SmtpClient.SendMailAsync(mailMessage);
        }
    }
}
