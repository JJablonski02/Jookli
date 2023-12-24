using Jookli.Commander.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.ReceiveMessage.Command
{
    internal class ReceiveMessageCommandHandler : ICommandHandler<ReceiveMessageCommand>
    {
        public async Task<Unit> Handle(ReceiveMessageCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
