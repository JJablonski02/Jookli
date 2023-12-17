using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Config
{
    public class EmailMessageConfigurationBuilder
    {
        protected MailMessage _mailMessage;

        public static EmailMessageConfigurationBuilder New => new EmailMessageConfigurationBuilder(new MailMessage());

        protected EmailMessageConfigurationBuilder(MailMessage mailMessage)
        {
            _mailMessage = mailMessage;
        }

        public EmailMessageConfigurationBuilder WithSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Subject can`t be NULL or empty string");
            }

            _mailMessage.Subject = subject;
            return this;
        }

        public EmailMessageConfigurationBuilder From(string address, string name)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address can`t be NULL or empty string");
            }

            if (name == null)
            {
                throw new ArgumentException("Name can`t be NULL");
            }

            try
            {
                _mailMessage.From = new MailAddress(address, name);
                _mailMessage.Sender = new MailAddress(address, name);
            }
            catch
            {
                throw new ArgumentException("Address is in invalid MailAddress format");
            }

            return this;
        }

        public EmailMessageConfigurationBuilder To(params string[] addresses)
        {
            if (addresses.Length == 0)
            {
                throw new ArgumentException("You must pass at least on receiver address");
            }

            if ((from c in addresses
                 group c by c into c
                 select c.Key).Count() < addresses.Length)
            {
                throw new ArgumentException("You must pass only distinct addresses, there are some copies in passed collection");
            }

            foreach (string text in addresses)
            {
                if (string.IsNullOrEmpty(text))
                {
                    throw new ArgumentException("Address can`t be NULL or empty string");
                }

                try
                {
                    new MailAddress(text);
                }
                catch
                {
                    throw new ArgumentException("Address : " + text + " is in invalid MailAddress format");
                }

                _mailMessage.To.Add(text);
            }

            return this;
        }

        public EmailMessageConfigurationBuilder WithBody(string body)
        {
            if (body == null)
            {
                throw new ArgumentException("Body can`t be NULL");
            }

            _mailMessage.Body = body;
            return this;
        }

        public EmailMessageConfigurationBuilder IsBodyHtml(bool isHtml)
        {
            _mailMessage.IsBodyHtml = isHtml;
            return this;
        }

        public EmailMessageConfigurationBuilder WithAttachment(Attachment attachment)
        {
            _mailMessage.Attachments.Add(attachment);
            return this;
        }

        public static implicit operator MailMessage(EmailMessageConfigurationBuilder mailMessageBuilder)
        {
            return mailMessageBuilder._mailMessage;
        }

        public MailMessage Build()
        {
            return _mailMessage;
        }
    }
}
