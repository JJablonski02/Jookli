﻿using Autofac;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Serilog;


namespace Jookli.Administrator.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }
        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = AdministratorCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger) where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(new
                IntegrationEventGenericHandler<T>());
        }
    }
}
