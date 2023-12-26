using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.User.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(UserEntity userEntity, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid userId, CancellationToken cancellationToken);
    }
}
