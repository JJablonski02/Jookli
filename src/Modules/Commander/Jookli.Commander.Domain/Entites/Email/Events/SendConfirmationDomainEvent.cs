﻿using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Entites.Email.Events
{
    public class SendConfirmationDomainEvent : DomainEventBase
    {
        public Guid EmailId { get; set; }
        public SendConfirmationDomainEvent(Guid emailId)
        {
            EmailId = emailId;
        }
    }
}
