using Jookli.UserAccess.Domain.Entities.UserDetails;
using Jookli.UserAccess.Domain.Entities.UserDetails.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Domain.UserDetails
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly UserAccessContext _userAccessContext;

        public UserDetailsRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }
        public async Task AddAsync(UserDetailsEntity userDetailsEntity, CancellationToken cancellationToken = default)
        {
            await _userAccessContext.UserDetails.AddAsync(userDetailsEntity, cancellationToken);
        }

        public async Task DeleteAsync(Guid userDetailsId, CancellationToken cancellationToken = default)
        {
            var result = await _userAccessContext.UserDetails.FirstOrDefaultAsync(x => x.UserDetailsId == userDetailsId, cancellationToken);
            if(result != null)
            {
                result.IsDeleted = true;
            }
        }

        public async Task<UserDetailsEntity> GetByIdAsync(Guid userDetailsId, CancellationToken cancellationToken = default)
        {
            return await _userAccessContext.UserDetails.FirstOrDefaultAsync(x => x.UserDetailsId == userDetailsId, cancellationToken);
        }

        public async Task UpdateAsync(UserDetailsEntity userDetailsEntity, CancellationToken cancellationToken = default)
        {
            var result = await _userAccessContext.UserDetails.FirstOrDefaultAsync(x => x.UserDetailsId == userDetailsEntity.UserDetailsId, cancellationToken);

            if(result != null )
            {
                
            }
        }
    }
}
