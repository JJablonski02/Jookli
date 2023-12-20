using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class UserRecoverPasswordIntegrationEvent : IntegrationEvent
    {
        public UserRecoverPasswordIntegrationEvent(Guid id, DateTime occuredOn, Guid userId, string callbackUrl) : base(id, occuredOn)
        {
            UserId = userId;
            CallbackUrl = callbackUrl;
        }
        public Guid UserId { get; }
        public string CallbackUrl { get; }
    }
}
