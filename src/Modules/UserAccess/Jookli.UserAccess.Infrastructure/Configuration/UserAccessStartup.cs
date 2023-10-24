using Autofac;
using Jookli.UserAccess.Infrastructure.Configuration.Mediation;
using Jookli.UserAccess.Infrastructure.Configuration.Processing;
using Jookli.UserAccess.Infrastructure.Configuration;
using Serilog;
using Jookli.BuildingBlocks.Application;
using Jookli.UserAccess.Infrastructure.Configuration.DataAccess;
using Serilog.AspNetCore;
using Jookli.UserAccess.Infrastructure.Configuration.Processing.Outbox;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.UserAccess.Application.Features.User.Register.Notification;
using Jookli.UserAccess.Infrastructure.Configuration.Domain;
using Jookli.UserAccess.Infrastructure.Configuration.EventsBus;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.Infrastructure.Configuration.Quartz;

namespace Jookli.UserAccess.Infrastructure.Configuration
{
    public static class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString, ILogger logger, 
            IExecutionContextAccessor executionContextAccessor, IEventsBus eventsBus, 
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "UserAccess");

            ConfigureCompositionRoot(connectionString, logger, executionContextAccessor, eventsBus);

            QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

            EventsBusStartup.Initialize(moduleLogger);
        }
        private static void ConfigureCompositionRoot(string connectionString, ILogger logger, IExecutionContextAccessor executionContextAccessor, IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));

            var domainNotificationsMap = new BiDictionary<string, Type>();

            domainNotificationsMap.Add("NewUserRegisteredNotification", typeof(NewUserRegisteredNotification));

            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container= containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);
        }
    }
}
