using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Application.Services;
using Jookli.Payments.Domain.Entities.Stripe.Customer;
using Jookli.Payments.Domain.Entities.User.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Customer.Create.Command
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly IStripeRepository _stripeRepository;
        private readonly IUserRepository _userRepository;
        public CreateCustomerCommandHandler(IStripeRepository stripeService, IUserRepository userRepository)
        {
            _stripeRepository = stripeService;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {

            var customer = new CustomerEntity
            {
                Email = command.Email,
                Name= command.Name,
            };

            var result = await _stripeRepository.CreateCustomerAsync(customer, cancellationToken);

            return Unit.Value;
        }
    }
}
