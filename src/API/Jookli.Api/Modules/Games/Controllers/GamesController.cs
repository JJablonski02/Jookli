using Jookli.Games.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Games.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController
    {
        private readonly IGamesModule _gamesModule;

        public GamesController(IGamesModule gamesModule)
        {
            _gamesModule = gamesModule;
        }
    }
}
