using Jookli.Payments.Domain.Entities.Card;
using Jookli.Payments.Domain.Entities.Card.RepositoryContract;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteCard(Guid cardId, CancellationToken cancellationToken)
        {
            var resuult = await _paymentsContext.Cards.Where(x => x.CardId == cardId).FirstOrDefaultAsync();
        }

        public async Task<CardEntity?> GetNumberAsync(string number, CancellationToken cancellationToken)
        {
            return await _paymentsContext.Cards.Where(x => x.CardNumber == number).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(CardEntity cardEntity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
