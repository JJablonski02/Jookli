using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Entities.Stripe.Customer
{
    public class CustomerResponseEntity : Entity
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string? Address { get; set; }
        public long Balance { get; set; }
    }
}
