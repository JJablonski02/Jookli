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
    public sealed class UserRepository : IUserRepository
    {
        private readonly UserAccessContext _dbContext;
        public UserRepository(UserAccessContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserAsync(UserEntity user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task<UserEntity?> GetByUserEmailAsync(string email)
        {
            return _dbContext.User.Where(temp => temp.Email == email).FirstOrDefaultAsync();
        }

        public Task<UserEntity?> GetByUserIdAsync(Guid userID)
        {
            return _dbContext.User.Where(temp => temp.UserID == userID).FirstOrDefaultAsync();
        }
    }
}
