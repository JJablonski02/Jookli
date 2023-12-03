using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Application.Configuration.Query;
using Jookli.Payments.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Card.Read
{
    internal sealed class ReadCardCommandHandler : IQueryHandler<ReadCardQuery, string>
    {
        public Task<string> Handle(ReadCardQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
