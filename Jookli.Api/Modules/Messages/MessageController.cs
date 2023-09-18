using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Messages
{
    public class MessageController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> PostMessage(string message)
        {
            return Ok();
        }
    }
}
