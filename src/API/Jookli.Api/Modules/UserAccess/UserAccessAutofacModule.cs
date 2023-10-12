using Autofac;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Infrastructure;

namespace Jookli.Api.Modules.Module
{
    internal sealed class UserAccessAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAccessModule>()
                .As<IUserAccessModule>()
                .InstancePerLifetimeScope();
        }
    }
}
