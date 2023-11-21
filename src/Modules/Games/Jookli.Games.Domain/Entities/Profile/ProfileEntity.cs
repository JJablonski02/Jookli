using Jookli.BuildingBlocks.Domain;
using Jookli.Games.Domain.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.Profile
{
    public class ProfileEntity : Entity
    {
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<GameEntity> Games { get; set; }

    }
}
