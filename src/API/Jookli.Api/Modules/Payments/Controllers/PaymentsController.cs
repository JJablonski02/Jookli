using Jookli.Payments.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api.Modules.Payments.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController
    {
        private readonly IPaymentsModule _paymentsModule;

        public PaymentsController(IPaymentsModule paymentsModule)
        {
            _paymentsModule = paymentsModule;
        }
    }
}
