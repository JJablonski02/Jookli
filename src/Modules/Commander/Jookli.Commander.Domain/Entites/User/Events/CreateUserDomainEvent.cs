using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.User.Events
{
    public class CreateUserDomainEvent : DomainEventBase
    {
        public CreateUserDomainEvent(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; }
    }
}
