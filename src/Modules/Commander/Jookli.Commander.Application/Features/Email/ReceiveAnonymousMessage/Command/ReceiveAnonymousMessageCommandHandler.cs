using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Domain.Entites.Email;
using Jookli.Commander.Domain.Entites.Email.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.Email.ReceiveAnonymousMessage.Command
{
    internal class ReceiveAnonymousMessageCommandHandler : ICommandHandler<ReceiveAnonymousMessageCommand>
    {
        private readonly IEmailRepository _emailRepository;

        public ReceiveAnonymousMessageCommandHandler(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }
        public async Task<Unit> Handle(ReceiveAnonymousMessageCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
