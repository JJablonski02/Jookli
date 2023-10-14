using Jookli.UserAccess.Application.Features.User.Register.Command;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jookli.Api.Configuration.Authorization;

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

        [HttpPost]
        [AllowAnonymous]
        [NoPermissionRequired]
        public async Task<IActionResult> CreateUser(RegisterCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }
    }
}
