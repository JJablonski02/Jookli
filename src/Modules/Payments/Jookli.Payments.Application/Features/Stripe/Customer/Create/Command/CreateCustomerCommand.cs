using Jookli.Payments.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Customer.Create.Command
{
    public class CreateCustomerCommand : CommandBase
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
