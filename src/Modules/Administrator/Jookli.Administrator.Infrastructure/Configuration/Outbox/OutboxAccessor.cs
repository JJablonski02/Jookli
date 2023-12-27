using Jookli.BuildingBlocks.Application.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Administrator.Infrastructure.Configuration.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly AdministratorContext _gamesContext;
        public OutboxAccessor(AdministratorContext userAccessContext)
        {
            _gamesContext = userAccessContext;
        }

        public void Add(OutboxMessage message)
        {
            _gamesContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask;
        }
    }
}
