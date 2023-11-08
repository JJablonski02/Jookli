using Jookli.BuildingBlocks.Domain;
using Jookli.Payments.Domain.Entities.Card;

namespace Jookli.Payments.Domain.Entities.User
{
    public class UserEntity : Entity
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CardSecret { get; set; }
        public CardEntity Card { get; set; }
    }
}
