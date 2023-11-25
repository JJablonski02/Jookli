using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Entities.User.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(UserEntity userEntity, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
