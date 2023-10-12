using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration
{
    internal static class UserAccessCompositionRoot
    {
        private static IContainer _container;

        internal static void SetContainer(IContainer container)
        {
            _container = container;
        }

        internal static ILifetimeScope BeginLifetimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}
