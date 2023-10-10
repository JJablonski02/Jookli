using Autofac;
using MediatR;
using System.Reflection;

namespace Jookli.Infrastructure.Configuration.Mediator
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly);
        }
    }
}
