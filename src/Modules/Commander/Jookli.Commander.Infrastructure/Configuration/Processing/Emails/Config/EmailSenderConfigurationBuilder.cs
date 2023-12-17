using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Config
{
    internal class EmailSenderConfigurationBuilder
    {
        protected EmailSenderConfiguration _config;

        public EmailSenderConfigurationBuilder(EmailSenderConfiguration emailSenderConfig)
        {
            _config = emailSenderConfig;
        }

        public EmailSenderConfigurationBuilder OnHost(string host)
        {
            _config.Host = host;
            return this;
        }

        public EmailSenderConfigurationBuilder WithDefaultSenderAddress(string email)
        {
            _config.DefaultSenderAddress = email;
            return this;
        }

        public EmailSenderConfigurationBuilder WithDefaultSenderDisplayName(string name)
        {
            _config.DefaultSenderDisplayName = name;
            return this;
        }

        public EmailSenderConfigurationBuilder UsingDeliveryFormat(SmtpDeliveryFormat format)
        {
            _config.DeliveryFormat = format;
            return this;
        }

        public EmailSenderConfigurationBuilder UsingDeliveryMethod(SmtpDeliveryMethod method)
        {
            _config.DeliveryMethod = method;
            return this;
        }

        public EmailSenderConfigurationBuilder EnableSSL(bool enable)
        {
            _config.EnableSSL = enable;
            return this;
        }

        public EmailSenderConfigurationBuilder OnPort(int port)
        {
            _config.Port = port;
            return this;
        }

        public EmailSenderConfigurationBuilder WithMaxAllowedTimeout(int timeout)
        {
            _config.Timeout = timeout;
            return this;
        }

        public EmailSenderConfigurationBuilder OnCredentials(string uid, string password)
        {
            _config.Password = password;
            _config.Uid = uid;
            return this;
        }

        public static implicit operator EmailSenderConfiguration(EmailSenderConfigurationBuilder builder)
        {
            return builder._config;
        }

        public EmailSenderConfiguration Build()
        {
            return _config;
        }
    }
}
