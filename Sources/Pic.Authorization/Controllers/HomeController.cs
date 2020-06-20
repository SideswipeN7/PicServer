using Microsoft.AspNetCore.Mvc;

namespace Pic.Shared.Authorization.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<string> Index() => Ok("Authorization Service");
    }
}