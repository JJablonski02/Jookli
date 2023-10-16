using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; }

        public DateTime OccuredOn { get; }

        public DomainEventBase()
        {
            this.Id = Guid.NewGuid();
            this.OccuredOn = DateTime.UtcNow;
        }
    }
}
