using Autofac;
using Jookli.Administrator.Application.Contracts;
using Jookli.Games.Infrastructure;

namespace Jookli.Api.Modules.Administrator
{
    public class AdministratorAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdministratorModule>()
                .As<IAdministratorModule>()
                .InstancePerLifetimeScope();
        }
    }
}
