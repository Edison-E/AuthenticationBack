namespace AuthBack.src.Application.Service;

public class TokenService : ServiceBase
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration, IMapper mapper, ILogger<TokenService> logger) : base (mapper, logger)
    {
        _configuration = configuration;
    }

    public string GenerateToken(LoginDTO login) 
    {
        string tokenGenerate = string.Empty;

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", login.Email) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenGenerate = tokenHandler.WriteToken(token);

            return tokenGenerate;
        }
        catch (Exception ex) 
        {
            _logger.LogError("Error: A ocurred white generate the token");
            return tokenGenerate;
        }
    }
}
