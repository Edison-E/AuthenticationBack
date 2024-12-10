using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Infrastructure.Repositorios;

namespace AuthBack.src.Application.Service;

public class AccountService
{
    private readonly IUserRepository _userRepository;
    public AccountService(UserRepository userrepository) 
    { 
     _userRepository = userrepository;
    }
    public Task<bool> VerifyCredentials(LoginDTO login) 
    { 
        return Task.FromResult(true);
    }
}
