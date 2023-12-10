using Jookli.BuildingBlocks.Domain;
using Jookli.Games.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.TapJoy
{
    public class TapJoyUserEntity : Entity
    {
        public Guid UserId { get; set; }
        public Guid TapJoyUserId { get; set; }
        public UserEntity User { get; set; }
    }
}
