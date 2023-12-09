using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.Email.Repository
{
    public interface IEmailRepository
    {
        Task AddAsync(EmailEntity email, CancellationToken cancellationToken = default);
    }
}
