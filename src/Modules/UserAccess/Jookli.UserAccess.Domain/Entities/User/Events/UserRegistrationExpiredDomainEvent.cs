﻿using Jookli.BuildingBlocks.Domain;
using Jookli.BuildingBlocks.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.User.Events
{
    public class UserRegistrationExpiredDomainEvent : DomainEventBase
    {
        public UserRegistrationExpiredDomainEvent(UserRegistrationId userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }

        public UserRegistrationId UserRegistrationId { get; }
    }
}
