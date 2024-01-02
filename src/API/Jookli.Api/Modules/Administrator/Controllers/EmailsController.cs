using Jookli.Administrator.Application.Contracts;
using Jookli.Administrator.Application.Features.EmailTemplate.Create.Command;
using Jookli.Api.Configuration.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Administrator.Controllers
{
    [Route("api/administrator/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IAdministratorModule _administratorModule;
        public EmailsController(IAdministratorModule administratorModule)
        {
            _administratorModule = administratorModule;
        }
        [HttpPost]
        [Route("createTemplate")]
        [AllowAnonymous]
        [NoPermissionRequired]
        public async Task<IActionResult> CreateTemplate(CreateEmailTemplateCommand createEmailTemplate)
        {
            await _administratorModule.ExecuteCommandAsync(createEmailTemplate);

            return Ok();
        }
    }
}
