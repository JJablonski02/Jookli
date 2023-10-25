using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Infrastructure.EventsBus
{
    public abstract class IntegrationEvent : INotification
    {
        public Guid Id { get; }
        public DateTime OccuredOn { get; }

        protected IntegrationEvent (Guid id, DateTime occuredOn)
        {
            Id = id;
            OccuredOn = occuredOn;
        }
    }
}
