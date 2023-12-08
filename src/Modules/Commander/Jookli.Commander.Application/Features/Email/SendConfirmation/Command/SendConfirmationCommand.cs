using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Jookli.Commander.Application.Configuration.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.SendConfirmation.Command
{
    internal class SendConfirmationCommand : InternalCommandBase
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }   
        public string CallbackUrl { get; set; }
        public SendConfirmationCommand(Guid id, Guid userId, string email, string callbackUrl) : base(id)
        {
            UserId = userId;
            Email = email;
            CallbackUrl = callbackUrl;
        }
    }
}
