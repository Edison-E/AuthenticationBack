using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController : Controller
{
    
    [HttpGet("Index")]
    [Authorize]
    public async Task<IActionResult> Index()
    {
        return Ok("Authenticated success");
    }
}
