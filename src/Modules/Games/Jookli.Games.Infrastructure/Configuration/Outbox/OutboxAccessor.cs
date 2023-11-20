using Jookli.BuildingBlocks.Application.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Configuration.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly GamesContext _gamesContext;
        public OutboxAccessor(GamesContext userAccessContext)
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
