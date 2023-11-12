﻿using Autofac;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using Serilog;


namespace Jookli.Payments.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(ILogger logger)
        {
            SubscribeIntegrationEvents(logger);
        }
        private static void SubscribeIntegrationEvents(ILogger logger)
        {
            var eventBus = PaymentsCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            SubscribeToIntegrationEvent<NewUserRegisteredIntegrationEvent>(eventBus, logger);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger) where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(new
                IntegrationEventGenericHandler<T>());
        }
    }
}
