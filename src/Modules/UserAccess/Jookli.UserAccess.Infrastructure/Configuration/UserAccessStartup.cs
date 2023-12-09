using Autofac;
using Jookli.UserAccess.Infrastructure.Configuration.Mediation;
using Jookli.UserAccess.Infrastructure.Configuration.Processing;
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
using Jookli.BuildingBlocks.Application.Emails;
using Jookli.UserAccess.Infrastructure.Configuration.Logging;
using Jookli.UserAccess.Application.Features.User.Remove.Notification;

namespace Jookli.UserAccess.Infrastructure.Configuration
{
    public static class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize(
           string connectionString,
           IExecutionContextAccessor executionContextAccessor,
           ILogger logger,
           EmailsConfiguration emailsConfiguration,
           string textEncryptionKey,
           IEmailSender emailSender,
           IEventsBus eventsBus,
           long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "UserAccess");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                logger,
                emailsConfiguration,
                textEncryptionKey,
                emailSender,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

            EventsBusStartup.Initialize(moduleLogger);
        }
        private static void ConfigureCompositionRoot(string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            string textEncryptionKey,
            IEmailSender emailSender,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "UserAccess")));

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());


            var domainNotificationsMap = new BiDictionary<string, Type>();

            domainNotificationsMap.Add("NewUserRegisteredNotification", typeof(NewUserRegisteredNotification));
            domainNotificationsMap.Add("UserRemovedNotification", typeof(UserRemovedNotification));
            domainNotificationsMap.Add("UserRegisterConfirmationNotification", typeof(SendEmailConfirmationNotification));

            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container= containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);
        }
    }
}
