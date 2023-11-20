using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.Profile.Events
{
    public class ProfileCreatedDomainEvent : DomainEventBase
    {
        public ProfileCreatedDomainEvent(Guid profileId, string profileName)
        {
            ProfileId = profileId;
            ProfileName = profileName; 
        }

        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
    }
}
