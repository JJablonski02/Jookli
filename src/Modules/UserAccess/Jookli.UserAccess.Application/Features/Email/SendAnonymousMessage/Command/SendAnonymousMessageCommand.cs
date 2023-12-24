using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendAnonymousMessage.Command
{
    public class SendAnonymousMessageCommand : CommandBase
    {
        public string? ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }
        public string Message { get; set; }
        public string Signature { get; set; }
    }
}
