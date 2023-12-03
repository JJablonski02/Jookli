using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Transactions.Withdraw.Command
{
    public class WithdrawMoneyCommandHandler : ICommandHandler<WithdrawMoneyCommand>
    {
        public Task<Unit> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
