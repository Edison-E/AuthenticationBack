using AuthBack.src.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

public class AccountController : ControllerBase
{
    public Task<bool> Login([FromBody] LoginDTO login)
    {
        bool userIsVerify;
        return Task.FromResult(true);
    }
}
