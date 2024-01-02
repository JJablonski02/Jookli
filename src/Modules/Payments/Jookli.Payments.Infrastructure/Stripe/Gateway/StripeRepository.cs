using Jookli.Payments.Application.Services;
using Jookli.Payments.Domain.Entities.Stripe.Customer;
using Stripe;
using Stripe.Checkout;

namespace Jookli.Payments.Infrastructure.Stripe.Gateway
{
    internal sealed class StripeRepository : IStripeRepository
    {
        private readonly PaymentsContext _paymentsContext;

        public StripeRepository(PaymentsContext paymentsContext)
        {
            _paymentsContext = paymentsContext;
        }
        public async Task AddCardAsync()
        {
            StripeConfiguration.ApiKey = "pk_test_51NkYOeR51GfcWcs80imMGXIGbxns82Vdl6uOfUWgYYqQUCBjmVdugbElAz6DzouaSpMXCDWVcOKb9Qzc43IqxWQi0055spy7vc";

            var config = new CustomerCreateOptions
            {
                Email = "343242@dfsfs.pl",
                Name = "Jakub Jablonski",
            };

            var service = new CustomerService();
            var result = await service.CreateAsync(config);
        }

        public async Task<CustomerResponseEntity?> CreateCustomerAsync(CustomerEntity customerEntity, CancellationToken cancellationToken = default)
        {
            //StripeConfiguration.ApiKey = "pk_test_51NkYOeR51GfcWcs80imMGXIGbxns82Vdl6uOfUWgYYqQUCBjmVdugbElAz6DzouaSpMXCDWVcOKb9Qzc43IqxWQi0055spy7vc";
            StripeConfiguration.ApiKey = "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";

            var config = new CustomerCreateOptions
            {
                Email = customerEntity.Email,
                Name = customerEntity.Name,
            };

            var service = new CustomerService();

            var customer = await service.CreateAsync(config);
            var customerResponse = new CustomerResponseEntity
            {
                Id = customer.Id,
                Balance = customer.Balance,
            };

            return customerResponse;
        }
    }
}
