using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Entities.Card.RepositoryContract
{
    public interface ICardRepository
    {
        Task AddAsync(CardEntity cardEntity, CancellationToken cancellationToken);
        Task<CardEntity?> GetNumberAsync(string number, CancellationToken cancellationToken);
        Task UpdateAsync(CardEntity cardEntity, CancellationToken cancellationToken);
        Task DeleteCard(Guid cardId, CancellationToken cancellationToken);
    }
}
