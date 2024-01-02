using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Stripe
{
    public interface IStripeService
    {
        string GetSecretAccessKey();
    }
}
