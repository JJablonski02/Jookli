using Jookli.Games.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.User.Command
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
