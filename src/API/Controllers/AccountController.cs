using AuthBack.src.Application.DTO;
using AuthBack.src.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

[Route("api/Controller")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Login")]
    public async Task<bool> Login([FromBody] LoginDTO login)
    {
        bool userIsVerify = await _accountService.VerifyCredentials(login);
        return userIsVerify;
    }
}
