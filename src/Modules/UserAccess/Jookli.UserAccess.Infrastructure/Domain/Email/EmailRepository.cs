using Jookli.UserAccess.Domain.Entities.Emails;
using Jookli.UserAccess.Domain.Entities.Emails.Repository;
using Microsoft.EntityFrameworkCore;


namespace Jookli.UserAccess.Infrastructure.Domain.Email
{
    public class EmailRepository : IEmailRepository
    {
        private readonly UserAccessContext _userAccessContext;

        public EmailRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }
        public async Task AddAsync(EmailEntity entity, CancellationToken cancellationToken)
        {
            await _userAccessContext.Email.AddAsync(entity, cancellationToken);
        }

        public async Task<EmailEntity?> GetByEmailIdAsync(Guid emailId, CancellationToken cancellationToken)
        {
            var email = await _userAccessContext.Email.Where(x => x.EmailId == emailId).FirstOrDefaultAsync(cancellationToken);

            return email;
        }

        public async Task<EmailEntity?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var email = await _userAccessContext.Email.Where(x => x.UserId == userId).FirstOrDefaultAsync(cancellationToken);

            return email;
        }
    }
}
