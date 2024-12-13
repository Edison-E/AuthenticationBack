using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Model;
using AutoMapper;

namespace AuthBack.src.Application.MappProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>(); 
        }
    }
}
