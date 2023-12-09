using Jookli.Commander.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.EmailTemplate.Repository
{
    public interface IEmailTemplateRepository
    {
        Task AddAsync(EmailTemplateEntity emailTemplate, CancellationToken cancellationToken = default);
        Task<EmailTemplateEntity?> GetFullyTemplateByTemplateTypeAsync(EmailTemplateType emailTemplateType, CancellationToken cancellationToken = default);
    }
}
