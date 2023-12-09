using Jookli.Commander.Domain.Entites.Email;
using Jookli.Commander.Domain.Entites.Email.Repository;

namespace Jookli.Commander.Infrastructure.Domain.Email
{
    public class EmailRepository : IEmailRepository
    {
        public readonly CommanderContext _commanderContext;

        public EmailRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public async Task AddAsync(EmailEntity email, CancellationToken cancellationToken = default)
        {
            await _commanderContext.Email.AddAsync(email, cancellationToken);
        }
    }
}
