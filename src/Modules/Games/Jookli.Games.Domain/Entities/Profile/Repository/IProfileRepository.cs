using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.Profile.Repository
{
    public interface IProfileRepository
    {
        Task AddAsync(ProfileEntity profileEntity, CancellationToken cancellationToken);
    }
}
