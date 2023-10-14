using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("JookliAPI", "Jookli API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {

        }
    }
}
