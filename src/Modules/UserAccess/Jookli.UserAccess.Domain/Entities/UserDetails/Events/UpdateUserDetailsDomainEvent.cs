using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.UserDetails.Events
{
    public class UpdateUserDetailsDomainEvent : DomainEventBase
    {
        public UpdateUserDetailsDomainEvent(Guid userDetailsId)
        {
            UserDetailsId = userDetailsId;
        }

        Guid UserDetailsId { get; set; }
    }
}
