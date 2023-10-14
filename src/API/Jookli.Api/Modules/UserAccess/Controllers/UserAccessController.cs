﻿using Jookli.Api.Configuration.Authorization;
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

        public UserAccessController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }


        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterNewUserRequest(RegisterCommand request)
        {
            await _userAccessModule.ExecuteCommandAsync(request);
                

            return Ok();
        }

    }
}
