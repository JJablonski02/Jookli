using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.UserDetails.Add.Command
{
    public class AddDetailsCommand : CommandBase
    {
        public Guid UserId { get; set; }
        public string? AreaCode { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender BaseInfoGender { get; set; }
        public string? DateOfBirth { get; set; }
        public string BaseInfoCountry { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string PlaceOfResidence { get; set; }
        public string Legacy { get; set; }
        public string PoliticalViews { get; set; }
        public string CurrentRelationShip { get; set; }
        public string Interesets { get; set; }
    }
}
