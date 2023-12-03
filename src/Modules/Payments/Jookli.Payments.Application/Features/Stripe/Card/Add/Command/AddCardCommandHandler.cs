using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Domain.Entities.Card.RepositoryContract;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jookli.Payments.Application.Features.Stripe.Card.Add.Command
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommand>
    {
        private readonly ICardRepository _cardRepository;
        public async Task<Unit> Handle(AddCardCommand command, CancellationToken cancellationToken)
        {
            var result = await _cardRepository.GetNumberAsync(command.CardNumber, cancellationToken);

            if (result != null)
            {
                throw new ArgumentException($"User with card number: {command.CardNumber} exists");
            }


            return Unit.Value;
        }
    }
}
