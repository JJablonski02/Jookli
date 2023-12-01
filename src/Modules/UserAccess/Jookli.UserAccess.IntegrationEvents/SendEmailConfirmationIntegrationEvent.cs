using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.IntegrationEvents
{
    public class SendEmailConfirmationIntegrationEvent : IntegrationEvent
    {
        public SendEmailConfirmationIntegrationEvent(Guid id, DateTime occuredOn) : base(id, occuredOn)
        {
        }
    }
}
