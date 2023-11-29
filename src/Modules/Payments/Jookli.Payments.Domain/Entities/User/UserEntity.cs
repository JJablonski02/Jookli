using Jookli.BuildingBlocks.Domain;
using Jookli.Payments.Domain.Entities.Card;
using Jookli.Payments.Domain.Entities.Game;

namespace Jookli.Payments.Domain.Entities.User
{
    public class UserEntity : Entity
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<CardEntity> Cards { get; set; }
        public ICollection<GameEntity> Games { get; set; }
    }
}
