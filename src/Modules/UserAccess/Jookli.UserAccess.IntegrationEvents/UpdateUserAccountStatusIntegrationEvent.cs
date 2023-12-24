using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class UpdateUserAccountStatusIntegrationEvent : IntegrationEvent
    {
        public UpdateUserAccountStatusIntegrationEvent(Guid id, DateTime occuredOn, Guid userId, AccountStatus accountStatus) : base(id, occuredOn)
        {
            UserId = userId;
            AccStatus = accountStatus;
        }

        public Guid UserId { get; }
        public AccountStatus AccStatus { get; }
    }
}
