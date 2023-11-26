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
        public Guid LocationId { get; set; }
        public UserEntity User { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LocationName { get; set; }
    }
}
