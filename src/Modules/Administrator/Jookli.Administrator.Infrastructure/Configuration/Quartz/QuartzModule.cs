using Autofac;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Administrator.Infrastructure.Configuration.Quartz
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
