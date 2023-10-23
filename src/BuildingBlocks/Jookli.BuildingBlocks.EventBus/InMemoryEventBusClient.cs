using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.EventBus
{
    internal class InMemoryEventBusClient : IEventsBus
    {
        private readonly ILogger _logger;
        public void Dispose()
        {
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            _logger.Information("Publishing {Event}", @event.GetType().FullName);
            await InMemoryEventBus.Instance.Publish(@event);
        }

        public void StartConsuming()
        {
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            InMemoryEventBus.Instance.Subscribe(handler);
        }
    }
}
