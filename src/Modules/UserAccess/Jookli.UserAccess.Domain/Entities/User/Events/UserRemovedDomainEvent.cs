using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class UserRemovedDomainEvent : DomainEventBase
    {
        public UserRemovedDomainEvent(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
