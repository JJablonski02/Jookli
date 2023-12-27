using Jookli.Games.Application.Contracts;
using Jookli.Games.Application.Features.User.Credentials.Command;
using Jookli.Games.Application.Features.User.Credentials.Query;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Games.Controllers
{
    [Route("api/games/credentials")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IGamesModule _gamesModule;

        public CredentialsController(IGamesModule gamesModule)
        {
            _gamesModule = gamesModule;
        }

        [HttpGet]
        [Route("GetCredentials")]
        public async Task<IActionResult> GetUserCredentials(string token)
        {
            var result = await _gamesModule.ExecuteQueryAsync(new GetCredentialsQuery(token));

            return Ok(result);
        }
    }
}
