using Autofac;
using Jookli.UserAccess.Application.Features.User.Register.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterCommand>();
        }
    }
}
