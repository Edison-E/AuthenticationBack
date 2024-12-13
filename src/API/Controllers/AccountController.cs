using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

[Route("api/Controller")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AccountController(IConfiguration configuration) 
    {
        _configuration = configuration;
    }

    [HttpGet("Login")]
    public async Task Login()
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(_configuration["Auth0:RedirectUrl"])
            .Build();

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme,authenticationProperties); 
    }    
}
