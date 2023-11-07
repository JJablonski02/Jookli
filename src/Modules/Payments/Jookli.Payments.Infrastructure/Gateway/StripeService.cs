using Jookli.Payments.Application.Services;
using Stripe;
using Stripe.Checkout;

namespace Jookli.Payments.Infrastructure.Gateway
{
    internal sealed class StripeService : IStripeService
    {
        public async Task AddCardAsync()
        {
            StripeConfiguration.ApiKey = "MyKey";

            var options = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = "4111111111111111",
                    ExpMonth = 12,
                    ExpYear = 2025,
                    Cvc = "123"
                }
            };

            var service = new TokenService();
            Token stripeToken = service.Create(options);

            var options = new AccountUpdateOptions
            {
                ExternalAccount = stripeToken.Id
            };

            var service = new AccountService();
            Account updatedAccount = service.Update("ID profilu użytkownika w Stripe", options);
        }
    }
}
