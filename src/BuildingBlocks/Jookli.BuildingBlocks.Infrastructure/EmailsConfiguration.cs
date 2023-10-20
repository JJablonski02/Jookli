using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure
{
    public class EmailsConfiguration
    {
        public EmailsConfiguration(string fromEmail)
        {
            FromEmail = fromEmail;
        }

        public string FromEmail { get;}
    }
}
