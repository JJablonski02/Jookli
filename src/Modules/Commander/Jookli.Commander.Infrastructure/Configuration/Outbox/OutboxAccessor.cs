using Jookli.BuildingBlocks.Application.Outbox;

namespace Jookli.Commander.Infrastructure.Configuration.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly CommanderContext _gamesContext;
        public OutboxAccessor(CommanderContext userAccessContext)
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
