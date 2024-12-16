using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

[Route("api/[Controller]")]
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
        var redirectUrl = Url.Action("Index","User");
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(redirectUrl)
            .Build();

        Console.WriteLine(redirectUrl);

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme,authenticationProperties); 
    }    
}
