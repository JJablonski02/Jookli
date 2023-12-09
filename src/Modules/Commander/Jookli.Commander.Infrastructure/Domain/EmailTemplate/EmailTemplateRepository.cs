using Jookli.Commander.Domain.Entites.EmailTemplate;
using Jookli.Commander.Domain.Entites.EmailTemplate.Repository;
using Jookli.Commander.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Domain.EmailTemplate
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private readonly CommanderContext _commanderContext;

        public EmailTemplateRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public async Task AddAsync(EmailTemplateEntity emailTemplate, CancellationToken cancellationToken)
        {
            await _commanderContext.EmailTemplate.AddAsync(emailTemplate, cancellationToken);
        }

        public async Task<EmailTemplateEntity?> GetFullyTemplateByTemplateTypeAsync(EmailTemplateType emailTemplateType, CancellationToken cancellationToken)
        {
            return await _commanderContext.EmailTemplate.Where(x => x.EmailTemplate == emailTemplateType).Include(x => x.EmailTemplateAttacheds).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
