using Jookli.UserAccess.Application.Authentication.Authenticate;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.User
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserAccessContext _dbContext;
        public UserRepository(UserAccessContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(UserEntity user, CancellationToken cancellationToken)
        {
            await _dbContext.User.AddAsync(user, cancellationToken);
        }

        public async Task<UserEntity?> GetByUserEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.User.Where(temp => temp.Email == email).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserEntity?> GetUserAndLoginAttemptsAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.User.Where(x => x.Email == email).Include(x => x.LoginAttempts).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserEntity?> GetByUserIdAsync(Guid userID, CancellationToken cancellationToken)
        {
            return await _dbContext.User.Where(temp => temp.UserId == userID).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
