using Autofac;
using Jookli.Games.Application.Contracts;
using Jookli.Games.Infrastructure;

namespace Jookli.Api.Modules.Games
{
    public class GamesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GamesModule>()
                .As<IGamesModule>().
                InstancePerLifetimeScope();
        }
    }
}
