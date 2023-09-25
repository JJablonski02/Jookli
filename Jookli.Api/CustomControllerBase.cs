using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jookli.Api
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
    }
}
