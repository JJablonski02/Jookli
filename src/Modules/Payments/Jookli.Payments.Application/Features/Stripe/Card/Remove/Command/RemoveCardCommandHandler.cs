using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Card.Remove.Command
{
    internal class RemoveCardCommandHandler : ICommandHandler<RemoveCardCommand>
    {
        public Task<Unit> Handle(RemoveCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
