using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Entities.Emails;
using Jookli.UserAccess.Domain.Entities.Emails.Repository;
using Microsoft.EntityFrameworkCore;

namespace Jookli.UserAccess.Infrastructure.Domain.Email
{
    public class AnonymousEmailRepository : IAnonymousEmailRepository
    {
        private readonly UserAccessContext _userAccessContext;

        public AnonymousEmailRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }

        public async Task AddAsync(AnonymousEmailEntity entity, CancellationToken cancellationToken)
        {
            await _userAccessContext.AnonymousEmail.AddAsync(entity, cancellationToken);
        }

        public async Task<AnonymousEmailEntity?> GetByEmailIdAsync(Guid emailId, CancellationToken cancellationToken)
        {
            var email = await _userAccessContext.AnonymousEmail.Where(x => x.EmailId == emailId).FirstOrDefaultAsync(cancellationToken);

            return email;
        }
    }
}
