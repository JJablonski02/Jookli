using Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(DbContext dbContext, IDomainEventsDispatcher domainEventsDispatcher)
        {
            _dbContext = dbContext;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default, Guid? internalCommandId = null)
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();

            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
