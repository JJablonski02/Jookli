using Jookli.UserAccess.Application.Features.Message;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Entities.Message;
using Jookli.UserAccess.Domain.Entities.User;
using Jookli.UserAccess.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MessageController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMessageGetterService _messageGetterService;
        private readonly IMessageAdderService _messageAdderService;

        public MessageController(IMessageGetterService messageGetterService, IMessageAdderService messageAdderService)
        {
            _messageGetterService = messageGetterService;
            _messageAdderService = messageAdderService;
        }

        //public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        //{
        //    if(_context.User == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.User.ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageResponse>> GetMessageById(Guid messageId)
        {
            MessageResponse? messageResponse = await _messageGetterService.GetMessageById(messageId);

            return messageResponse;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage(MessageRequest messageRequest)
        {
            await _messageAdderService.AddMessage(messageRequest);

            return Ok();
        }

        [HttpGet]

        public async Task<ActionResult<MessageResponse>> GetMessage(MessageRequest messageRequest)
        {
            MessageResponse messageResponse = await _messageGetterService.GetMessage(messageRequest);
            return messageResponse;
        }
    }
}
