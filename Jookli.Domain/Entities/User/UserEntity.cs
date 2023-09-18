using Jookli.Domain.Entities.Message;
using System.ComponentModel.DataAnnotations;

namespace Jookli.Domain.Entities.User
{
    public class UserEntity
    {
        [Key]
        public Guid UserID { get; set; }
        [StringLength(50)]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public bool IsSystemAccount { get; set; }
        public bool Premium { get; set; }
        public ICollection<MessageEntity>? MessagesReceived { get; set; }
    }
}
