using Autofac;
using Jookli.Commander.Application.Contracts;
using Jookli.Commander.Infrastructure;

namespace Jookli.Api.Modules.Commander
{
    public class CommanderAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommanderModule>()
                .As<ICommanderModule>()
                .InstancePerLifetimeScope();
        }
    }
}
