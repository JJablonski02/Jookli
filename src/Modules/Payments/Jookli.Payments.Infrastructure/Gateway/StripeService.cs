using Jookli.Payments.Application.Services;
using Stripe;
using Stripe.Checkout;

namespace Jookli.Payments.Infrastructure.Gateway
{
    internal sealed class StripeService : IStripeService
    {
        public async Task AddCardAsync()
        {
            StripeConfiguration.ApiKey = "pk_test_51NkYOeR51GfcWcs80imMGXIGbxns82Vdl6uOfUWgYYqQUCBjmVdugbElAz6DzouaSpMXCDWVcOKb9Qzc43IqxWQi0055spy7vc";

            var config = new CustomerCreateOptions
            {
                Email = "343242@dfsfs.pl",
                Name = "Jakub Jablonski",
            };
            var service = new TokenService();

            var options = new TokenCreateOptions
            {
            };
        }
    }
}
