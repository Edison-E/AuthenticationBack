using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok("Authenticated success");
            }

            return Unauthorized("Credentials is invalid");
        }
    }
}
