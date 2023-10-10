using Autofac;
using Jookli.Infrastructure.Configuration.Processing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        private static void SubscribeIntegrationEvents(ILogger logger)
        {
            var eventBus = UserCompositionRoot.BeginLifetimeScope().Resolve<IEventBus>();
        }
    }
}
