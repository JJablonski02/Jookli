using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.UserDetails.Events
{
    public class AddUserDetailsDomainEvent : DomainEventBase
    {
        public AddUserDetailsDomainEvent(Guid userDetailsId)
        {
            UserDetailsId = userDetailsId;
        }

        public Guid UserDetailsId { get; }
    }
}
