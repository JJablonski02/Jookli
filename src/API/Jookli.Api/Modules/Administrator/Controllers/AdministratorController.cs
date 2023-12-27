using Jookli.Administrator.Application.Contracts;
using Jookli.Api.Configuration.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Administrator.Controllers
{
    [Route("api/administrator")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorModule _administratorModule;

        public AdministratorController(IAdministratorModule administratorModule)
        {
            _administratorModule = administratorModule;
        }

        [AllowAnonymous]
        [NoPermissionRequired]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAdministratorStatus()
        {
            //To do
            return Ok();
        }
    }
}
