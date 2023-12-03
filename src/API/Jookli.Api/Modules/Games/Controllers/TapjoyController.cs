using Jookli.Api.Configuration.Authorization;
using Jookli.Games.Application.Contracts;
using Jookli.Games.Application.Features.Games.Tapjoy.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Games.Controllers
{
    [Route("api/games/tapjoy")]
    [ApiController]
    public class TapjoyController : ControllerBase
    {
        private readonly IGamesModule _gamesModule;

        public TapjoyController(IGamesModule gamesModule)
        {
            _gamesModule = gamesModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetDetails")]

        public async Task<IActionResult> GetDetails(ReadUserDetailsCommand readUserDetailsCommand)
        {
           var result = await _gamesModule.ExecuteQueryAsync(readUserDetailsCommand);

            return Ok();
        }
    }
}
