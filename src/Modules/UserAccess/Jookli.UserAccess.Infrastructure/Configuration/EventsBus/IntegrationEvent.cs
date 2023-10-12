using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Infrastructure.Configuration.EventsBus
{
    public abstract class IntegrationEvent : INotification
    {
        public Guid Id { get; set; }
        public DateTime OccuredOn { get; set; }

        protected IntegrationEvent (Guid id, DateTime occuredOn)
        {
            Id = id;
            OccuredOn = occuredOn;
        }
    }
}
