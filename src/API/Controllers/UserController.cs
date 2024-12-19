namespace AuthBack.src.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserService _userService;
    public UserController (UserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet("GetProfile")]
    public async Task<IActionResult> GetProfile()
    {
        string email = User.FindFirst(ClaimTypes.Email).Value;
        if (email is null)
        {
            return BadRequest("Email is empty");
        }

        UserDTO user = await _userService.GetUser(email);
        if (user is null)
        {
           return Unauthorized("Not have unauthorized !!!"); 
        }

        return Ok(new {name = user.Username, email = user.Email });      
    }
}
