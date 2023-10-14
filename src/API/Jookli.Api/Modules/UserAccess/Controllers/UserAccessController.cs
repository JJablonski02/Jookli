using Jookli.Api.Configuration.Authorization;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Application.Features.User.Register.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.UserAccess.Controllers
{
    [Route("api/userAccess/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;


        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateNewUser(RegisterCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }
    }

}
