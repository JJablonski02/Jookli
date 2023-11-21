using Autofac;
using Jookli.BuildingBlocks.Application;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.Games.Infrastructure.Configuration.DataAccess;
using Jookli.Games.Infrastructure.Configuration.Domain;
using Jookli.Games.Infrastructure.Configuration.EventsBus;
using Jookli.Games.Infrastructure.Configuration.Logging;
using Jookli.Games.Infrastructure.Configuration.Processing.Outbox;
using Jookli.Games.Infrastructure.Configuration.Processing;
using Jookli.Games.Infrastructure.Configuration.Quartz;
using Jookli.Games.Infrastructure.Configuration.Mediation;
using Serilog;
using Serilog.Extensions.Logging;
using Jookli.Games.Application.Features.Profile.Notification;

namespace Jookli.Games.Infrastructure.Configuration
{
    public class GamesStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "Games");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                logger,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

            EventsBusStartup.Initialize(moduleLogger);
        }



        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Games")));

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();
            domainNotificationsMap.Add("ProfileCreatedNotification", typeof(ProfileCreatedNotification));

            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            GamesCompositionRoot.SetContainer(_container);
        }
    }
}
