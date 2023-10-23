using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.EventsBus
{
    public interface IEventsBus : IDisposable
    {
        Task Publish<T>(T @event)
            where T : IntegrationEvent;

        void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent;

        void StartConsuming();
    }
}
