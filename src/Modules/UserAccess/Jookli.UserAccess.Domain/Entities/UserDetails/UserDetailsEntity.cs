using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.UserDetails
{
    public class UserDetailsEntity : Entity
    {
        public Guid UserId { get; set; }
        public Guid UserDetailsId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AreaCode { get; set; }
        public int PhoneNumber { get; set; }
        public Gender Gender { get; set; } 
        public Gender BaseInfoGender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BaseInfoCountry { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string PlaceOfResidence { get; set; }
        public string Legacy { get; set; }
        public string PoliticalViews { get; set; }
        public string CurrentRelationShip { get; set; }
        public string Interesets { get; set; }
        public UserEntity User { get; set; }
    }
}
