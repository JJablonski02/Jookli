using Jookli.Api.Configuration.Authorization;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Application.Features.Email.SendAnonymousMessage.Command;
using Jookli.UserAccess.Application.Features.Email.SendMessage.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.UserAccess.Controllers
{
    [Route("api/useraccess/email")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;

        public EmailsController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("SendAnonymous")]
        public async Task<IActionResult> SendAnonymous(SendAnonymousMessageCommand sendAnonymousMessage)
        {
            await _userAccessModule.ExecuteCommandAsync(sendAnonymousMessage);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send(SendMessageCommand sendMessageCommand)
        {
            await _userAccessModule.ExecuteCommandAsync(sendMessageCommand);

            return Ok();
        }

    }
}
