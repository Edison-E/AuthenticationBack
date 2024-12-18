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
        User user = await _userRepository.GetByEmail(email);
        UserDTO userDTO = _mapper.Map<UserDTO>(user);

        return userDTO;
    }
}
