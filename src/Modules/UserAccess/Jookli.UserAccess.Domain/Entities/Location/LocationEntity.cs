using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Location
{
    public class LocationEntity : Entity
    {
        public Guid UserId { get; set; }
        public Guid LocationId { get; set; }

        public ICollection<LocationServicesEntity> Services { get; set; }
        public bool IsAllowed { get; set; }
        public TimeSpan Interval { get; set; }
        public UserEntity User { get; set; }
    }
}
