using Jookli.BuildingBlocks.Domain;

namespace Jookli.Payments.Domain.Entities.User
{
    public class UserEntity : Entity
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
