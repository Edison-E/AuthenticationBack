using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AuthBack.src.Application.Service;

public class AccountService : ServiceBase
{
    private readonly IUserRepository _userRepository;
    public AccountService(IUserRepository userRepository, IMapper mapper, ILogger<AccountService> logger) : base (mapper, logger)
    { 
        _userRepository = userRepository;
    }

    public async Task<bool> VerifyCredentials(LoginDTO login)
    {
            User userByEmail = await _userRepository.GetByEmail(login.Email);
            User userById = await _userRepository.GetById(userByEmail.Id);

            bool passwordIsVerify = await VerifyPassword(userById.Password, login.Password);
            bool emailIsVerify = await VerifyEmail(userById.Email, login.Email);

            return emailIsVerify && passwordIsVerify;
    }

    private async Task<bool> VerifyPassword(string userPassword, string loginpPassword)
    {
        bool passwordIsVerify = BCrypt.Net.BCrypt.Verify(loginpPassword, userPassword);
        return passwordIsVerify;
    }

    private async Task<bool> VerifyEmail(string userEmail, string loginEmail)
    {
        bool emailIsVerify = userEmail == loginEmail;
        return emailIsVerify;
    }

}
