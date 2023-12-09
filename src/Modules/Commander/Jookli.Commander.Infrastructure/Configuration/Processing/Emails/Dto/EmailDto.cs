using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Dto
{
    public class EmailDto
    {
        public Guid EmailJobQueueId { get; set; }
        public Guid EmailAccountId { get; set; }
        public string EmailName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Recipient { get; set; }
        public EmailAccountDto EmailAccount { get; set; }
        public List<EmailAttachedDto> EmailAttached { get; set; }
    }
}
