using Jookli.Domain.Entities.Message;
using System.ComponentModel.DataAnnotations;

namespace Jookli.Domain.Entities.User
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [StringLength(50)]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public bool IsSystemAccount { get; set; }
        public bool Premium { get; set; }
        public ICollection<MessageReceived>? MessagesReceived { get; set; }
        public ICollection<MessageSent>? MessagesSent { get; set; }
    }
}
