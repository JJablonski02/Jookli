using Jookli.Games.Domain.Entities.User;
using Jookli.Games.Domain.Entities.User.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Domain.User.Repository
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly GamesContext _gamesContext;

        public UserRepository(GamesContext gamesContext)
        {
            _gamesContext = gamesContext;
        }

        public async Task AddAsync(UserEntity userEntity, CancellationToken cancellationToken)
        {
            await _gamesContext.Users.AddAsync(userEntity, cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid Id, CancellationToken cancellationToken)
        {
            return await _gamesContext.Users.AnyAsync(x => x.UserId == Id);
        }
    }
}
