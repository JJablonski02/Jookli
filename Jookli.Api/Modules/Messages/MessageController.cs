using Jookli.Application.DTO;
using Jookli.Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Messages
{
    public class MessageController : Controller
    {
        private readonly IMessageGetterService _messageGetterService;
        private readonly IMessageAdderService _messageAdderService;

        public MessageController()
        {
            
        }

        [HttpGet]
        public async Task<JsonResult> GetMessage(Guid messageId)
        {
            MessageResponse? messageResponse = await _messageGetterService.GetMessageById(messageId);

            return Json(messageResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage(MessageRequest messageRequest)
        {
            await _messageAdderService.AddMessage(messageRequest);

            return Ok();
        }
    }
}
