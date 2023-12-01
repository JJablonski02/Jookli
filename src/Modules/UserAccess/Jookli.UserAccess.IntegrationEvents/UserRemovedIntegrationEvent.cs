using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class UserRemovedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; }
        public UserRemovedIntegrationEvent(Guid id, DateTime occuredOn, Guid userId) : base(id, occuredOn)
        {
            UserId = userId;
        }
    }
}
