using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.Location
{
    public class LocationServicesEntity : Entity
    {
        public Guid LocationId { get; set; }
        public Guid LocationServiceId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public DateTime TimeStamp { get; set; }
        public LocationEntity Location { get; set; }
    }
}
