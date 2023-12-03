using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Transactions.Verify.Command
{
    public class VerifyTransactionCommandHandler : ICommandHandler<VerifyTransactionCommand>
    {
        public Task<Unit> Handle(VerifyTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
