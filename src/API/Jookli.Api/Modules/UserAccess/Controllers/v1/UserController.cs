using Jookli.UserAccess.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.UserAccess.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : CustomControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;

        public UserController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[NoPermissionRequired]
        //public async Task<IActionResult> CreateUser(RegisterCommand command)
        //{
        //    await _userAccessModule.ExecuteCommandAsync(command);

        //    return Ok();
        //}
    }
}
