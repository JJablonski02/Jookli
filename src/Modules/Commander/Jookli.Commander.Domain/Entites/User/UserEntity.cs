using Jookli.BuildingBlocks.Domain;


namespace Jookli.Commander.Domain.Entites.User
{
    public class UserEntity : Entity
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }
        public string Password { get; set; }
    }
}
