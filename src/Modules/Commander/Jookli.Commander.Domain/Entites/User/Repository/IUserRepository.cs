using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.User.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(UserEntity user, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid userId, CancellationToken cancellationToken); 
    }
}
