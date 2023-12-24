using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Emails.Repository
{
    public interface IAnonymousEmailRepository
    {
        Task<AnonymousEmailEntity?> GetByEmailIdAsync(Guid emailId, CancellationToken cancellationToken);
        Task AddAsync(AnonymousEmailEntity entity, CancellationToken cancellationToken);
    }
}
