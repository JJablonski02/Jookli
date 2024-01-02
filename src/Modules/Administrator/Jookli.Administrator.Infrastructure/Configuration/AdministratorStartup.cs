using Autofac;
using Jookli.BuildingBlocks.Application;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.Administrator.Infrastructure.Configuration.DataAccess;
using Jookli.Administrator.Infrastructure.Configuration.Domain;
using Jookli.Administrator.Infrastructure.Configuration.EventsBus;
using Jookli.Administrator.Infrastructure.Configuration.Logging;
using Jookli.Administrator.Infrastructure.Configuration.Processing.Outbox;
using Jookli.Administrator.Infrastructure.Configuration.Processing;
using Jookli.Administrator.Infrastructure.Configuration.Quartz;
using Jookli.Administrator.Infrastructure.Configuration.Mediation;
using Serilog;
using Serilog.Extensions.Logging;

namespace Jookli.Administrator.Infrastructure.Configuration
{
    public class AdministratorStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "Administrator");

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

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Administrator")));

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();

            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            AdministratorCompositionRoot.SetContainer(_container);
        }
    }
}
