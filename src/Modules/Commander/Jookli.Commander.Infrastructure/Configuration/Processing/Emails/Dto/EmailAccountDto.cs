using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Dto
{
    public class EmailAccountDto
    {
        public Guid EmailAccountId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string SmtpLogin { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
    }
}
