using Autofac;
using Jookli.Application.ServiceContracts;
using Jookli.Infrastructure;

namespace Jookli.Api.Modules.Module
{
    internal sealed class IdentityAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityService>()
                .As<IIdentityService>()
                .InstancePerLifetimeScope();
        }
    }
}
