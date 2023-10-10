using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Infrastructure.Configuration.EventsBus
{
    public interface IEventBus : IDisposable
    {
        Task Publish<T>(T @event)
            where T : IntegrationEvent;

        void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent;

        void StartConsuming();
    }
}
