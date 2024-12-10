using AuthBack.src.Application.DTO;
using AuthBack.src.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

[Route("api/Controller")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly TokenService _tokenService;

    public AccountController(AccountService accountService, TokenService tokenService)
    {
        _accountService = accountService;
        _tokenService = tokenService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO login)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(login.Password);
        bool userIsVerify = await _accountService.VerifyCredentials(login);

        if (userIsVerify)
        {
            var token = _tokenService.GenerateToken(login);
            return Ok(token);
        }
        return BadRequest("Email or password is incorrect");
    }
}
