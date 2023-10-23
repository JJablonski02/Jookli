using Jookli.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _jookliDbContext;

        public DomainEventsAccessor(DbContext jookliDbContext)
        {
            _jookliDbContext = jookliDbContext;
        }

        public void ClearAllDomainEvents()
        {
            var domainEntites = this._jookliDbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntites.ForEach(entity => entity.Entity.ClearDomainEvents());
        }

        public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntites = this._jookliDbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntites.SelectMany(x => x.Entity.DomainEvents).ToList();
        }
    }
}
