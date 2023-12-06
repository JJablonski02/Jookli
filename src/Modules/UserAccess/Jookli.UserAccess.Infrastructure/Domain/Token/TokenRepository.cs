using Jookli.UserAccess.Domain.Entities.Token;
using Jookli.UserAccess.Domain.Entities.Token.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.Token
{
    public class TokenRepository : ITokenRepository
    {
        private readonly UserAccessContext _userAccessContext;
        public TokenRepository(UserAccessContext userAccessContext)
        {

            _userAccessContext = userAccessContext;

        }
        public async Task AddAsync(TokenEntity tokenEntity, CancellationToken cancellationToken)
        {
            await _userAccessContext.Token.AddAsync(tokenEntity, cancellationToken);
        }
    }
}
