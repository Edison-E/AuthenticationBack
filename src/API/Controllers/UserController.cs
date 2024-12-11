using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return Ok("Usuario autenticado, entrando sistema...");
        }
    }
}
