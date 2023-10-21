using Jookli.UserAccess.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Remove.Command
{
    public sealed class RemoveUserCommand : CommandBase<Unit>
    {
        public RemoveUserCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
