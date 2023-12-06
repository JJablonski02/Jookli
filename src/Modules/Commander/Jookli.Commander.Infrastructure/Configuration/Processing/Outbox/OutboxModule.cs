using Autofac;
using Jookli.BuildingBlocks.Application.Events;
using Jookli.BuildingBlocks.Application.Outbox;
using Jookli.BuildingBlocks.Infrastructure;
using Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using Jookli.Commander.Infrastructure.Configuration.Outbox;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Outbox
{
    internal class OutboxModule : Autofac.Module
    {
        private readonly BiDictionary<string, Type> _domainNotificationMap;

        public OutboxModule(BiDictionary<string, Type> domainNotificationMap)
        {
            _domainNotificationMap = domainNotificationMap;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OutboxAccessor>()
                .As<IOutbox>()
                .FindConstructorsWith(new AllConstructorFinder())
                .InstancePerLifetimeScope();

            CheckMappings();

            builder.RegisterType<DomainNotificationsMapper>()
                .As<IDomainNotificationsMapper>()
                .FindConstructorsWith(new AllConstructorFinder())
                .WithParameter("domainNotificationsMap", _domainNotificationMap)
                .SingleInstance();
        }

        private void CheckMappings()
        {
            var domainEventNotifications = Assemblies.Application
                .GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDomainEventNotification)))
                .ToList();
            List<Type> notMappedNotifications = new List<Type>();

            foreach (var domainEventNotification in domainEventNotifications)
            {
                _domainNotificationMap.TryGetBySecond(domainEventNotification, out var name);

                if (name == null)
                {
                    notMappedNotifications.Add(domainEventNotification);
                }
            }

            if (notMappedNotifications.Any())
            {
                throw new ApplicationException($"Domain Event Notifications {notMappedNotifications.Select(n => n.FullName).Aggregate((x, y) => x + "," + y)} not mapped");
            }
        }
    }
}
