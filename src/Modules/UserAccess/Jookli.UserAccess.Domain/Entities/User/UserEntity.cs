using Jookli.UserAccess.Domain.Entities.Message;
using Jookli.UserAccess.Domain.Entities.VoiceMessage;
using Jookli.UserAccess.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jookli.UserAccess.Domain.Entities.User
{
    public class UserEntity
    {
        [Key]
        public Guid UserID { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int PhoneNumber { get; set; } 
        public DateTime DateOfLastLogin { get; set; }
        public bool Deleted { get; set; } 
        public bool Premium { get; set; }
        public bool IsMicrophoneAllowed { get; set; }
        public bool PushNotifications { get; set; }

        public ICollection<MessageEntity>? MessagesReceived { get; set; }
        public ICollection<VoiceMessageEntity>? VoiceMessagesReceived { get; set; } 
    }
}
