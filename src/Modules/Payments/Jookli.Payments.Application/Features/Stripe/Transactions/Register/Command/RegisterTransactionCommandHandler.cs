using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Transactions.Register.Command
{
    public class RegisterTransactionCommandHandler : ICommandHandler<RegisterTransactionCommand>
    {
        public Task<Unit> Handle(RegisterTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
