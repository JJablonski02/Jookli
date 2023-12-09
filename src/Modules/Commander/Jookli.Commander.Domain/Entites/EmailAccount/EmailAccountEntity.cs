using Jookli.BuildingBlocks.Domain;
using Jookli.Commander.Domain.Entites.Email;
using Jookli.Commander.Domain.Entites.EmailTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.EmailAccount
{
    public class EmailAccountEntity : Entity
    {
        public Guid EmailAccountId { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Pop3Server { get; set; }
        public string? Pop3Port { get; set; }
        public string? Pop3Login { get; set; }
        public string? Pop3Password { get; set; }
        public string? SmtpServer { get; set; }
        public int? SmtpPort { get; set; }
        public string? SmtpLogin { get; set; }
        public string? SmtpPassword { get; set; }
        public string? ImapServer { get; set; }
        public int? ImapPort { get; set; }
        public string? ImapLogin { get; set; }
        public string? ImapPassword { get; set; }
        public ICollection<EmailTemplateEntity> EmailTemplates { get; set; }
        public ICollection<EmailEntity> Emails { get; set; }
    }
}
