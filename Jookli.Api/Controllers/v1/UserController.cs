using Jookli.Application.Features.User.Register.Command;
using Jookli.Application.ServiceContracts;
using Jookli.Domain.Entities.User;
using Jookli.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IIdentityService _userService;
        public UserController(ApplicationDbContext context, IIdentityService identityService)
        {
            _userService = identityService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            return await _context.User.ToListAsync();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(RegisterCommand command)
        {
            await _userService.ExecuteCommandAsync(command);

            return Ok();
        }
    }
}
