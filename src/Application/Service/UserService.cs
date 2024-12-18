using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using AutoMapper;

namespace AuthBack.src.Application.Service;

public class UserService : ServiceBase
{
    private readonly IUserRepository _userRepository;
    public UserService(IMapper mapper, ILogger<UserService> logger, IUserRepository userRepository) : base(mapper, logger)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetUser(string email)
    {
        UserDTO userDTO = null;
        try
        {
            User user = await _userRepository.GetByEmail(email);
            if (user is null)
            {
                _logger.LogWarning("Warning: No user find with this email {email}. ",email);
            }
            
            userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError("A ocurred while get user with this email {email}. ",email);
            return userDTO;
        }
    }
}
