using Autofac;
using Jookli.UserAccess.Infrastructure.Configuration.Mediation;
using Jookli.UserAccess.Infrastructure.Configuration.Processing;
using Jookli.UserAccess.Infrastructure.Configuration;
using Serilog;
using Jookli.BuildingBlocks.Application;
using Jookli.UserAccess.Infrastructure.Configuration.DataAccess;
using Serilog.AspNetCore;

namespace Jookli.UserAccess.Infrastructure.Configuration
{
    public static class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString, ILogger logger, IExecutionContextAccessor executionContextAccessor)
        {
            var moduleLogger = logger.ForContext("Module", "UserAccess");

            ConfigureCompositionRoot(connectionString, logger, executionContextAccessor);
        }
        private static void ConfigureCompositionRoot(string connectionString, ILogger logger, IExecutionContextAccessor executionContextAccessor)
        {
            var containerBuilder = new ContainerBuilder();

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container= containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);
        }
    }
}
