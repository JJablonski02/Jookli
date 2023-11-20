using Jookli.BuildingBlocks.Application.Events;
using Jookli.Games.Domain.Entities.Profile.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.Profile.Notification
{
    internal class ProfileCreatedNotification : DomainNotificationBase<ProfileCreatedDomainEvent>
    {
        public ProfileCreatedNotification(ProfileCreatedDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
