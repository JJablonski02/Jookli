using Jookli.Application.ServiceContracts;
using Jookli.Infrastructure.Configuration.Processing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Infrastructure
{
    public class IdentityModule : IIdentityService
    {
        public async Task ExecuteCommandAsync (IRequest request)
        {
             await CommandsExecutor.Execute(request);
        }
    }
}