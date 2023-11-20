using Jookli.Games.Domain.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.Profile
{
    public class ProfileEntity
    {
        public Guid profileId { get; set; }
        public string profileName { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<GameEntity> games { get; set; }

    }
}
