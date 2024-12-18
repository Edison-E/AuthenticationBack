using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using AutoMapper;

namespace AuthBack.src.Application.Service;

public class AccountService : ServiceBase
{
    private readonly IUserRepository _userRepository;
    public AccountService(IUserRepository userRepository, IMapper mapper, ILogger<AccountService> logger) 
        : base (mapper, logger)
    { 
        _userRepository = userRepository;
    }

    public async Task<bool> VerifyCredentials(LoginDTO login)
    {
        try
        {
            User userByEmail = await _userRepository.GetByEmail(login.Email);
            if (userByEmail is null)
            {
                _logger.LogWarning("Error: No user found with this email {Email}. ", login.Email);
                return false;
            }

            bool passwordIsVerify =  VerifyPassword(userByEmail.Password, login.Password);
            if (!passwordIsVerify)
            {
                _logger.LogWarning("Error: Password {Password} is Incorrect .",login.Password); 
                return false;
            }

            return passwordIsVerify;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: An occurred while verifing credentials for email {Email}.", login.Email);
            return false;
        }
    }

    private bool VerifyPassword(string userPassword, string loginpPassword)
    {
        bool passwordIsVerify = BCrypt.Net.BCrypt.Verify(loginpPassword, userPassword);
        return passwordIsVerify;
    }

}
