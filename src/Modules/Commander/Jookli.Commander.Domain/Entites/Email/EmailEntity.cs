using Jookli.BuildingBlocks.Domain;
using Jookli.Commander.Domain.Entites.EmailAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.Email
{
    public class EmailEntity : Entity
    {
        public Guid EmailId { get; set; }
        public Guid EmailAccountId { get; set; }
        public EmailAccountEntity EmailAccount { get; set; }
        public string? EmailName { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? Recipement { get; set; }
        public string? Error { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public ICollection<EmailAttachedEntity> EmailAttacheds { get; set; }
    }
}
