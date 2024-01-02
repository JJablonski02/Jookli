using IdentityServer4.Models;
using IdentityServer4.Services;
using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.IdentityServer
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.AddRange(context.Subject.Claims.Where(c => c.Type == CustomClaimTypes.Roles).ToList());
            context.IssuedClaims.Add(context.Subject.Claims.Single(c => c.Type == CustomClaimTypes.Email));

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(context.IsActive);
        }
    }
}
