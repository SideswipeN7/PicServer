using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Pic.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Produces(MediaTypeNames.Text.Plain)]
        public ActionResult<string> Get() => "Server is runing!";
    }
}