using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthBack.src.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    [HttpGet("Login")]
    public async Task Login()
    {
        var redirectUrl = Url.Action("Callback","Account", null, Request.Scheme);
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(redirectUrl)
            .Build();

        Console.WriteLine(redirectUrl);

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme,authenticationProperties); 
    }

    [HttpGet("callback")]
    public async Task<IActionResult> Callback()
    {
        return Ok(new { message ="Authenticated success" });
    }
}
