using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Dto
{
    public class EmailAttachedDto
    {
        public Guid EmailAttachedId { get; set; }
        public Guid EmailId { get; set; }
        public string FilePath { get; set; }
        public string? Name { get; set; }
    }
}
