using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.User.Events
{
    public class CreateUserDomainEvent : DomainEventBase
    {
        public CreateUserDomainEvent(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
