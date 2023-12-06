using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Token.Events
{
    public class TokenCreatedDomainEvent : DomainEventBase
    {
        public TokenCreatedDomainEvent(Guid userId, TokenPurpose tokenPurpose)
        {
            UserId = userId;
            TokenPurpose = tokenPurpose;
        }
        public Guid UserId { get; set; }
        public TokenPurpose TokenPurpose { get; set; }
    }
}
