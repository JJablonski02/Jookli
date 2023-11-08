using Jookli.Payments.Domain.Entities.Card;
using Jookli.Payments.Domain.Entities.Card.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Domain.Card.Repository
{
    internal sealed class CardRepository : ICardRepository
    {
        private readonly PaymentsContext _paymentsContext;

        public CardRepository(PaymentsContext paymentsContext)
        {
            _paymentsContext = paymentsContext;
        }

        public async Task AddAsync(CardEntity cardEntity, CancellationToken cancellation = default)
        {
            await _paymentsContext.Cards.AddAsync(cardEntity, cancellation);
        }
    }
}
