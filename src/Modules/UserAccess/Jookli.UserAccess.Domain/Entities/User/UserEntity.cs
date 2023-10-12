using Jookli.Domain.Entities.Message;
using Jookli.Domain.Entities.VoiceMessage;
using System.ComponentModel.DataAnnotations;

namespace Jookli.Domain.Entities.User
{
    public class UserEntity
    {
        [Key]
        public Guid UserID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; } 
        public string Email { get; set; }
        public DateTime DateOfLastLogin { get; set; }
        public bool Premium { get; set; }
        public bool IsMicrophoneAllowed { get; set; }
        public bool PushNotifications { get; set; }

        public ICollection<MessageEntity>? MessagesReceived { get; set; }
        public ICollection<VoiceMessageEntity>? VoiceMessagesReceived { get; set; } 
    }
}
