﻿using Autofac;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Infrastructure;

namespace Jookli.Api.Modules.UserAccess
{
    internal sealed class UserAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAccessModule>()
                .As<IUserAccessModule>()
                .InstancePerLifetimeScope();
        }
    }
}
