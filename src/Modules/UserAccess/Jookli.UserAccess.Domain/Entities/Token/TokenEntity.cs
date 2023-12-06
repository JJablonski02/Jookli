using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.User;

namespace Jookli.UserAccess.Domain.Entities.Token
{
    public class TokenEntity : Entity
    {
        public Guid TokenId { get; set; }
        public Guid UserId { get; set; }
        public string TokenValue { get; set; }
        public bool IsValid { get; set; } = true;
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Metadata { get; set; }
        public UserEntity User { get; set; }
    }
}
