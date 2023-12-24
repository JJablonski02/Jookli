using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Token.Repository
{
    public interface ITokenRepository
    {
        Task AddAsync(TokenEntity tokenEntity, CancellationToken cancellationToken);
        Task<TokenEntity?> GetByValue(string tokenValue,  CancellationToken cancellationToken);
    }
}
