using Jookli.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Domain.Entities.Game
{
    public class GameEntity : Entity
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
    }
}
