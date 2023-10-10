using Autofac;
using Jookli.Infrastructure.Configuration.Mediator;
using Jookli.Infrastructure.Configuration.Processing;
using Serilog;

namespace Jookli.Infrastructure.Configuration
{
    public class IdentityStartup
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

            UserCompositionRoot.SetContainer(_container);
        }
    }
}
