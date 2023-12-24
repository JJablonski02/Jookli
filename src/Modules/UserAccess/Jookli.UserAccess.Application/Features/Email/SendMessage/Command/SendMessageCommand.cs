using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.Email.SendMessage.Command
{
    public class SendMessageCommand : CommandBase
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
    }
}
