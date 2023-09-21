using Jookli.Application.DTO;
using Jookli.Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Messages
{
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageGetterService _messageGetterService;
        private readonly IMessageAdderService _messageAdderService;

        public MessageController()
        {
            
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<JsonResult> GetMessageById(Guid messageId)
        {
            MessageResponse? messageResponse = await _messageGetterService.GetMessageById(messageId);

            return Json(messageResponse);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> PostMessage(MessageRequest messageRequest)
        {
            await _messageAdderService.AddMessage(messageRequest);

            return Ok();
        }

        [Route("[action]")]
        [HttpGet]

        public async Task<JsonResult> GetMessage(MessageRequest messageRequest)
        {
            MessageResponse messageResponse = await _messageGetterService.GetMessage(messageRequest);
            return Json(messageResponse);
        }


    }
}
