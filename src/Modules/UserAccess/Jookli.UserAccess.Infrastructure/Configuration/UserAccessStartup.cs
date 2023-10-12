using Autofac;
using Jookli.UserAccess.Infrastructure.Configuration.Mediation;
using Jookli.UserAccess.Infrastructure.Configuration.Processing;
using Jookli.UserAccess.Infrastructure.Configuration;
using Serilog;

namespace Jookli.UserAccess.Infrastructure.Configuration
{
    public class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize(string connectionString, ILogger logger)
        {
            ConfigureCompositionRoot(connectionString, logger);
        }
        private static void ConfigureCompositionRoot(string connectionString, ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());

            _container= containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);
        }
    }
}
