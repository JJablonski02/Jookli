using Jookli.Commander.Domain.Entites.User;
using Jookli.Commander.Domain.Entites.User.Repository;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Commander.Infrastructure.Domain.User.Repository
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly CommanderContext _commanderContext;

        public UserRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public async Task AddAsync(UserEntity userEntity, CancellationToken cancellationToken)
        {
            await _commanderContext.Users.AddAsync(userEntity, cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid Id, CancellationToken cancellationToken)
        {
            return await _commanderContext.Users.AnyAsync(x => x.UserId == Id);
        }
    }
}
