using Jookli.Api.Configuration.Authorization;
using Jookli.Commander.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Commander.Controllers
{
    [Route("api/commander")]
    [ApiController]
    public class CommanderController : ControllerBase
    {
        private readonly ICommanderModule _commanderModule;

        public CommanderController(ICommanderModule commanderModule)
        {
            _commanderModule = commanderModule;
        }
        [AllowAnonymous]
        [NoPermissionRequired]
        [HttpGet("")]
        public async Task<IActionResult> GetModuleStatus()
        {
            //To do
            return Ok();
        }
    }
}
