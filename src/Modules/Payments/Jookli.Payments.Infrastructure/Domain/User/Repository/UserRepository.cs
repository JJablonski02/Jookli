using Jookli.Payments.Domain.Entities.User;
using Jookli.Payments.Domain.Entities.User.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Domain.User.Repository
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly PaymentsContext _paymentsContext;

        public UserRepository(PaymentsContext paymentsContext)
        {
            _paymentsContext = paymentsContext;
        }

        public async Task AddAsync(UserEntity userEntity, CancellationToken cancellationToken = default)
        {
            await _paymentsContext.User.AddAsync(userEntity, cancellationToken);
        }

        public async Task<bool> ExistAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _paymentsContext.User.AnyAsync(x => x.UserId == userId, cancellationToken);
        }
    }
}
