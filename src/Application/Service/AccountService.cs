using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using AutoMapper;

namespace AuthBack.src.Application.Service;

public class AccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public AccountService(IUserRepository userrepository, IMapper mapper) 
    { 
        _userRepository = userrepository;
        _mapper = mapper;
    }

    public async Task<bool> VerifyCredentials(LoginDTO login)
    {
        User userByEmail = await _userRepository.GetByEmail(login.Email);
        User userById = await _userRepository.GetById(userByEmail.Id);

        bool passwordIsVerify = await VerifyPassword(userById, login.Password);
        bool emailIsVerify = await VerifyEmail(userById, login.Email);

        return emailIsVerify && passwordIsVerify;
    }

    public async Task<bool> VerifyPassword(User user, string password)
    {
        bool passwordIsVerify = BCrypt.Net.BCrypt.Verify(password, user.Password);
        return passwordIsVerify;
    }

    public async Task<bool> VerifyEmail(User user, string email)
    {
        bool emailIsVerify = user.Email == email;
        return emailIsVerify;
    }

    public async Task<UserDTO> GetUser( LoginDTO login)
    {
        bool userIsVerify = await VerifyCredentials(login);

        if (userIsVerify)
        {
            User user = await _userRepository.GetByEmail(login.Email);
            UserDTO userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        return null;
    }
}
