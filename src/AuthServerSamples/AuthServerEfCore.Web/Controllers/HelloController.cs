using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthServerEfCore.Web.Controllers
{
    [Route("hello")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> World() => Ok("World");
    }
}