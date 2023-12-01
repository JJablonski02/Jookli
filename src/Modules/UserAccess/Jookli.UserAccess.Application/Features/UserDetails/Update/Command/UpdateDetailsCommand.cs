using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.UserDetails.Update.Command
{
    public class UpdateDetailsCommand : CommandBase
    {
        public Guid UserId { get; set; }
        public string? AreaCode { get; set; }
        public Gender BaseInfoGender { get; set; }
        public string? DateOfBirth { get; set; } = null;
        public string? BaseInfoCountry { get; set; } = null;
        public string? Education { get; set; } = null;
        public string? Specialization { get; set; } = null;
        public string? PlaceOfResidence { get; set; } = null;
        public string? Legacy { get; set; } = null;
        public string? PoliticalViews { get; set; } = null;
        public string? CurrentRelationShip { get; set; } = null;
        public string? Interesets { get; set; } = null;
    }
}
