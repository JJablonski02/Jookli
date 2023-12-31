﻿using Jookli.Payments.Domain.Entities.Stripe.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Services
{
    public interface IStripeRepository
    {
        Task<CustomerResponseEntity> CreateCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken = default);
    }
}
