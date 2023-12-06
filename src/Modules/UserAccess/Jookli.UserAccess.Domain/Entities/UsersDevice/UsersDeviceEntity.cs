using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.UsersDevice
{
    public class UsersDeviceEntity : Entity
    {
        public Guid UsersDeviceId { get; set; }
        public Guid UserId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public string OsVersion { get; set; }
        public string IpAddress { get; set; }
        public string Platform { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserEntity User { get; set; }
    }
}
