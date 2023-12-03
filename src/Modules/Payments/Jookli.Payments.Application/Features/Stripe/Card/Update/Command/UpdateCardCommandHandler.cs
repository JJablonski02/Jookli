using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Card.Update.Command
{
    public class UpdateCardCommandHandler : ICommandHandler<UpdateCardCommand>
    {
        public Task<Unit> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
