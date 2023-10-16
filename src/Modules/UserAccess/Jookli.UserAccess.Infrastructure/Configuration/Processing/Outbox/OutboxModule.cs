using Autofac;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.UserAccess.Infrastructure.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing.Outbox
{
    internal class OutboxModule : Module
    {
        private readonly BiDictionary<string, Type> _domainNotificationMap;

        public OutboxModule(BiDictionary<string, Type> domainNotificationMap)
        {
            _domainNotificationMap = domainNotificationMap;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OutboxAccessor>
        }
    }
}
