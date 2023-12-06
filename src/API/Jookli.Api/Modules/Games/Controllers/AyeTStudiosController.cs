using Jookli.Api.Configuration.Authorization;
using Jookli.Games.Application.Contracts;
using Jookli.Games.Application.Features.Games.AyeTStudios.Callback;
using Jookli.Games.Application.Features.Games.Tapjoy.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Games.Controllers
{
    [ApiController]
    [Route("api/ayetstudios")]
    public class AyeTStudiosController : ControllerBase
    {
        private readonly IGamesModule _gamesModule;

        public AyeTStudiosController(IGamesModule gamesModule)
        {
            _gamesModule = gamesModule; 
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetUserDetails")]

        public async Task<IActionResult> GetUserDetails(ReadUserDetailsCommand readUserDetailsCommand)
        {
            var result = await _gamesModule.ExecuteQueryAsync(readUserDetailsCommand);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("Callback")]
        public async Task<IActionResult> Callback([FromBody]AyetCallbackCommand ayetCallbackCommand)
        {
            await _gamesModule.ExecuteCommandAsync(ayetCallbackCommand);

            return Ok();
        }
    }
}
