using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.Message;
using Jookli.UserAccess.Domain.Entities.VoiceMessage;
using Jookli.UserAccess.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jookli.UserAccess.Domain.Entities.User
{
    public class UserEntity : Entity
    {
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string AreaCode { get; set; }
        public Gender Gender { get; set; }
        public Gender BaseInfoGender { get; set; }
        public string BaseInfoCountry { get; set; }
        public DateTime DateOfBirth { get;set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string PlaceOfResidence { get; set; }
        public string Legacy { get; set; }
        public string PoliticalViews { get; set; }
        public string CurrentRelationShip { get; set; }
        public string Interesets { get; set; }
        public int PhoneNumber { get; set; } 
        public DateTime DateOfLastActivity { get; set; }
        public bool IsDeleted { get; set; } 
        public bool Premium { get; set; }
        public bool IsMicrophoneAllowed { get; set; }
        public bool PushNotifications { get; set; }

        public ICollection<MessageEntity>? MessagesReceived { get; set; }
        public ICollection<VoiceMessageEntity>? VoiceMessagesReceived { get; set; } 
    }
}
