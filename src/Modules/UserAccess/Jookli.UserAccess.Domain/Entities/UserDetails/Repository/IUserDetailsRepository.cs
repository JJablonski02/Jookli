using Jookli.UserAccess.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.UserDetails.Repository
{
    public interface IUserDetailsRepository
    {
        Task AddAsync(UserDetailsEntity userDetailsEntity, CancellationToken cancellationToken = default);
        Task UpdateAsync(UserDetailsEntity userDetailsEntity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid userDetailsId, CancellationToken cancellationToken = default);
        Task<UserDetailsEntity?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
