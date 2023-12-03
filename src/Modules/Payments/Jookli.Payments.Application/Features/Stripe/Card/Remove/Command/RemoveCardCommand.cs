using Jookli.Payments.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Card.Remove.Command
{
    public class RemoveCardCommand : CommandBase
    {
        public RemoveCardCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
