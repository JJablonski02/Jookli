using Autofac;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.IntegrationEvents;
using Serilog;


namespace Jookli.Commander.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }
        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = CommanderCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            SubscribeToIntegrationEvent<NewUserRegisteredIntegrationEvent>(eventBus, logger);
            SubscribeToIntegrationEvent<SendEmailConfirmationIntegrationEvent>(eventBus, logger);
            SubscribeToIntegrationEvent<UserPasswordChangedIntegrationEvent>(eventBus, logger);
            SubscribeToIntegrationEvent<UserRecoverPasswordIntegrationEvent>(eventBus, logger);
            SubscribeToIntegrationEvent<SendMessageIntegrationEvent>(eventBus, logger);
            SubscribeToIntegrationEvent<SendAnonymousMessageIntegrationEvent>(eventBus, logger);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger) where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(new
                IntegrationEventGenericHandler<T>());
        }
    }
}
