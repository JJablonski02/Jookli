using Autofac;
using Quartz;

namespace Jookli.Payments.Infrastructure.Configuration.Quartz
{
    public class QuartzModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(IJob).IsAssignableFrom(t))
                .InstancePerDependency();
        }
    }
}
