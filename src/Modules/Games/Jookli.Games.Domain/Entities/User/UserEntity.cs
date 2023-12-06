using Jookli.BuildingBlocks.Domain;
using Jookli.Games.Domain.Entities.AyeTStudios;
using Jookli.Games.Domain.Entities.TapJoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.User
{
    public class UserEntity : Entity
    {
        public Guid UserId { get; set; } 
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<AyetUserEntity> AyetUsers { get; set;}
        public ICollection<TapJoyUserEntity> TapJoyUsers { get; set;}
    }
}
