using Autofac;
using Jookli.BuildingBlocks.Application;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.Payments.Infrastructure.Configuration.DataAccess;
using Jookli.Payments.Infrastructure.Configuration.Domain;
using Jookli.Payments.Infrastructure.Configuration.EventsBus;
using Jookli.Payments.Infrastructure.Configuration.Logging;
using Jookli.Payments.Infrastructure.Configuration.Mediation;
using Jookli.Payments.Infrastructure.Configuration.Processing;
using Jookli.Payments.Infrastructure.Configuration.Processing.Outbox;
using Jookli.Payments.Infrastructure.Configuration.Quartz;
using Serilog;
using Serilog.Extensions.Logging;


namespace Jookli.Payments.Infrastructure.Configuration
{
    public class PaymentsStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "Payments");

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

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Payments")));

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

            PaymentsCompositionRoot.SetContainer(_container);
        }
    }
}
