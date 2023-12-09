using Jookli.Api.Configuration.Authorization;
using Jookli.UserAccess.Application.Authentication.Authenticate;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Application.Features.User.Register.Command;
using Jookli.UserAccess.Application.Features.User.Remove.Command;
using Jookli.UserAccess.Application.Features.User.ResetPassword.Command;
using Jookli.UserAccess.Application.Features.UserDetails.Add;
using Jookli.UserAccess.Application.Features.UserDetails.Add.Command;
using Jookli.UserAccess.Application.Features.UserDetails.Update.Command;
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
        public async Task<IActionResult> RegisterUser(RegisterCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpDelete]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(RemoveUserCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPut]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("AddDetails")]
        public async Task<IActionResult> AddUserDetails(AddDetailsCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }
        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPut]
        [Route("UpdateDetails")]
        public async Task<IActionResult> UpdateUserDetails(UpdateDetailsCommand command)
        {
            await _userAccessModule.ExecuteCommandAsync(command);

            return Ok();
        }

        //[NoPermissionRequired]
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("ConfirmAccount")]
        //public async Task<IActionResult> ConfirmAccount([FromQuery]Guid UserId, [FromQuery]string token)
        //{
        //    await _userAccessModule.ExecuteQueryAsync();
        //}
    }
}
