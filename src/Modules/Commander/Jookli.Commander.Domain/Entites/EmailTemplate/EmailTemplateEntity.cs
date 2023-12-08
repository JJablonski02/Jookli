using Jookli.Commander.Domain.Entites.EmailAccount;
using Jookli.Commander.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.EmailTemplate
{
    public class EmailTemplateEntity
    {
        public Guid EmailTemplateId { get; set; }
        public Guid EmailAccountId { get; set; }
        public EmailAccountEntity EmailAccount { get; set; }
        public string EmailName { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string SenderName { get; set; }
        public bool Active { get; set; }
        public EmailTemplateType EmailTemplate { get; set; }
        public ICollection<EmailTemplateAttachedEntity> EmailTemplateAttacheds { get; set; }
    }
}
