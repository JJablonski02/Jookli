using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Config
{
    internal sealed class EmailSenderConfiguration
    {
        private string host;

        private string uid;

        private string password;

        private string defaultSenderAddress;

        private string defaultSenderDisplayName;

        private int port;

        private int timeout = 100000;

        public string Host
        {
            get
            {
                return host;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Host can`t be NULL or empty string");
                }

                host = value;
            }
        }

        public string Uid
        {
            get
            {
                return uid;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Uid can`t be NULL or empty string");
                }

                uid = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Password can`t be NULL");
                }

                password = value;
            }
        }

        public string DefaultSenderAddress
        {
            get
            {
                return defaultSenderAddress;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("DefaultSenderAddress can`t be NULL or empty string");
                }

                try
                {
                    MailAddress mailAddress = new MailAddress(value);
                }
                catch
                {
                    throw new ArgumentException("DefaultSenderAddress is in invalid MailAddress format");
                }

                defaultSenderAddress = value;
                if (string.IsNullOrEmpty(defaultSenderDisplayName))
                {
                    defaultSenderDisplayName = value;
                }
            }
        }

        public string DefaultSenderDisplayName
        {
            get
            {
                return defaultSenderDisplayName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("DefaultSenderDisplayName can`t be NULL");
                }

                defaultSenderDisplayName = value;
            }
        }

        public SmtpDeliveryFormat DeliveryFormat { get; set; } = SmtpDeliveryFormat.International;


        public SmtpDeliveryMethod DeliveryMethod { get; set; } = SmtpDeliveryMethod.Network;


        public bool EnableSSL { get; set; }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Port number can`t be 0 or less");
                }

                port = value;
            }
        }

        public int Timeout
        {
            get
            {
                return timeout;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Timeout number can`t be 0 or less");
                }

                timeout = value;
            }
        }

        public static EmailSenderConfigurationBuilder New => new EmailSenderConfigurationBuilder(new EmailSenderConfiguration());
    }
}
