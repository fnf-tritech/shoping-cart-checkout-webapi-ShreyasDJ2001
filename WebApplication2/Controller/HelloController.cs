using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controller
{
    [ApiController]
    [Route("/[Controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello Worldd");
        }
    }
}
