using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class UpdateUserAccountStatusDomainEvent : DomainEventBase
    {
        public UpdateUserAccountStatusDomainEvent(Guid userId, AccountStatus accountStatus)
        {
            UserId = userId;
            AccStatus = accountStatus;
        }
        
        public Guid UserId { get; set; }
        public AccountStatus AccStatus { get; set; }
    }
}
