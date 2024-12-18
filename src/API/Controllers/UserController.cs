using AuthBack.src.Application.DTO;
using AuthBack.src.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        if (user is not null)
        {
            return Ok(new {name = user.Username, email = user.Email });
        }

        return Unauthorized("Not have unauthorized !!!"); 
    }
}
