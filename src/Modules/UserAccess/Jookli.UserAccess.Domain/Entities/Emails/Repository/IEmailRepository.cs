using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Emails.Repository
{
    public interface IEmailRepository
    {
        Task<EmailEntity?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<EmailEntity?> GetByEmailIdAsync(Guid emailId, CancellationToken cancellationToken);
        Task AddAsync(EmailEntity entity, CancellationToken cancellationToken);
    }
}
