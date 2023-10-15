﻿using Autofac;
using Autofac.Core;
using Jookli.BuildingBlocks.Application.Events;
using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Domain;
using Jookli.BuildingBlocks.Infrastructure.Serialization;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;

        private readonly ILifetimeScope _scope;

        private readonly IDomainEventsAccessor _domainEventsAccessor;

        private readonly IDomainNotificationsMapper _domainNotificationsMapper;

        private readonly IOutbox _outbox;

        public DomainEventsDispatcher(
            IMediator mediator, 
            ILifetimeScope scope, 
            IDomainEventsAccessor domainEventsAccessor, 
            IDomainNotificationsMapper domainNotificationsMapper, 
            IOutbox outbox
            )
        {
            _mediator= mediator;
            _scope= scope;
            _domainEventsAccessor= domainEventsAccessor;
            _domainNotificationsMapper= domainNotificationsMapper;
            _outbox= outbox;
        }
        public async Task DispatchEventsAsync()
        {
            var domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();

            foreach(var domainEvent in domainEvents )
            {
                Type domainEventNotificationType = typeof(IDomainEventNotification<>);
                var domainNotificationWtihGenericType = domainEventNotificationType.MakeGenericType(domainEvent.GetType());
                var domainNotification = _scope.ResolveOptional(domainNotificationWtihGenericType, new List<Parameter>
                {
                    new NamedParameter("domainEvent", domainEvent),
                    new NamedParameter("id", domainEvent.Id)
                });

                if(domainNotification != null)
                {
                    domainEventNotifications.Add(domainNotification as IDomainEventNotification<IDomainEvent>);
                }
            }

            
        }
    }
}
