using Autofac;
using Jookli.UserAccess.Infrastructure.Configuration.Processing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        private static void SubscribeIntegrationEvents(ILogger logger)
        {
            var eventBus = UserAccessCompositionRoot.BeginLifetimeScope().Resolve<IEventBus>();
        }
    }
}
