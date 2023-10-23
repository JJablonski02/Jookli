using Autofac;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Serilog;


namespace Jookli.UserAccess.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(ILogger logger)
        {
            SubscribeIntegrationEvents(logger);
        }
        private static void SubscribeIntegrationEvents(ILogger logger)
        {
            var eventBus = UserAccessCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

        }

        private static void SubsciteIntegrationEvents<T>(IEventsBus eventBus, ILogger logger) where T : IntegrationEvent
        {
            logger.Information("Subscrive to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(new
                IntegrationEventGenericHandler<T>());
        }
    }
}
