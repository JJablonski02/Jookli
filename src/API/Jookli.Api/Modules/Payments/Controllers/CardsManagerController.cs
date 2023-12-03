using Jookli.Api.Configuration.Authorization;
using Jookli.Payments.Application.Contracts;
using Jookli.Payments.Application.Features.Stripe.Card.Add.Command;
using Jookli.Payments.Application.Features.Stripe.Card.Read;
using Jookli.Payments.Application.Features.Stripe.Card.Remove.Command;
using Jookli.Payments.Application.Features.Stripe.Card.Update.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Payments.Controllers
{
    [Route("api/cardsManager")]
    [ApiController]
    public class CardsManagerController : ControllerBase
    {
        private readonly IPaymentsModule _paymentsModule;

        public CardsManagerController(IPaymentsModule paymentsModule)
        {
            _paymentsModule = paymentsModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCard(AddCardCommand addCardCommand)
        {
            await _paymentsModule.ExecuteCommandAsync(addCardCommand);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCard(UpdateCardCommand updateCardCommand)
        {
            await _paymentsModule.ExecuteCommandAsync(updateCardCommand);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCard(RemoveCardCommand deleteCardCommand)
        {
            await _paymentsModule.ExecuteCommandAsync(deleteCardCommand);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet]
        [Route("Read")]

        public async Task<IActionResult> ReadCard(ReadCardQuery readCardCommand)
        {
            var result = await _paymentsModule.ExecuteQueryAsync(readCardCommand);

            return Ok();
        }
    }
}
