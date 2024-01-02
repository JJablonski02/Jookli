using Jookli.Api.Configuration.Authorization;
using Jookli.Payments.Application.Contracts;
using Jookli.Payments.Application.Features.Stripe.Customer.Create.Command;
using Jookli.Payments.Application.Features.Stripe.Transactions.Register.Command;
using Jookli.Payments.Application.Features.Stripe.Transactions.Verify.Command;
using Jookli.Payments.Application.Features.Stripe.Transactions.Withdraw.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Payments.Controllers
{
    [ApiController]
    [Route("api/payments/stripe")]
    public class StripeController : ControllerBase
    {
        private readonly IPaymentsModule _paymentsModule;

        public StripeController(IPaymentsModule paymentsModule)
        {
            _paymentsModule = paymentsModule;
        }

        [NoPermissionRequired]
        [HttpPost]
        [Route("Withdraw")]
        public async Task<IActionResult> WithdrawMoney(WithdrawMoneyCommand withdrawMoneyCommand)
        {
            await _paymentsModule.ExecuteCommandAsync(withdrawMoneyCommand);

            return Ok();
        }
        [NoPermissionRequired]
        [HttpPost]
        [Route("RegisterTransaction")]
        public async Task<IActionResult> RegisterTransaction(RegisterTransactionCommand registerTransactionCommand)
        {
            await _paymentsModule.ExecuteCommandAsync(registerTransactionCommand);

            return Ok();
        }
        [NoPermissionRequired]
        [HttpPost]
        [Route("VerifyTransaction")]
        public async Task<IActionResult> VerifyTransaction(VerifyTransactionCommand verifyTransactionCommand)
        {
            await _paymentsModule.ExecuteCommandAsync(verifyTransactionCommand);

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost]
        [Route("CreateConsumer")]
        public async Task<IActionResult> CreateConsumer(CreateCustomerCommand createCustomer)
        {
            await _paymentsModule.ExecuteCommandAsync(createCustomer);

            return Ok();
        }


    }
}
