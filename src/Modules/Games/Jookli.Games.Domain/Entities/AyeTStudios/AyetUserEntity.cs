using Jookli.BuildingBlocks.Domain;
using Jookli.Games.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Domain.Entities.AyeTStudios
{
    public class AyetUserEntity : Entity
    {
        public Guid UserId { get; set; }
        public Guid AyetUserId { get; set; }
        public float Payout { get; set; }
        public float CurrencyAmount { get; set; }
        public string externalIdentifier { get; set; }
        public int UserIntId { get; set; }
        public string PlacementIdentifier { get; set; }
        public int AdslotId { get; set; }
        public string TransactionId { get; set; } 
        public UserEntity User { get; set; }
    }
}
