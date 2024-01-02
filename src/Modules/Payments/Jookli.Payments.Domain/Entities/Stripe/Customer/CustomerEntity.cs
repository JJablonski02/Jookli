using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Entities.Stripe.Customer
{
    public class CustomerEntity : Entity
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
