using Jookli.Api.Configuration.Authorization;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Application.Features.User.Register.Command;
using Jookli.UserAccess.Application.Features.User.Remove.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.UserAccess.Controllers
{
    [Route("api/userAccess")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;

        public UserAccessController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }


        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterNewUserRequest(RegisterCommand request)
        {
            await _userAccessModule.ExecuteCommandAsync(request);
                
            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(RemoveUserCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }
    }
}
