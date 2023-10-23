using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsDispatcherNotificationHandlerDecorator<T> : INotificationHandler<T> where T : INotification
    {
        private readonly INotificationHandler<T> _decorator;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public DomainEventsDispatcherNotificationHandlerDecorator(INotificationHandler<T> decorator, IDomainEventsDispatcher domainEventsDispatcher)
        {
            _decorator = decorator;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            await this._decorator.Handle(notification, cancellationToken);

            await this._domainEventsDispatcher.DispatchEventsAsync();
        }
    }
}
