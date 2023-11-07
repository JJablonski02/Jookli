using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Domain.Entities.Card.RepositoryContract;
using MediatR;

namespace Jookli.Payments.Application.Features.Card.Add.Command
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommand>
    {
        private readonly ICardRepository _cardRepository;
        public Task<Unit> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
