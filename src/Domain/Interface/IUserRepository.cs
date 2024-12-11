using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Model;

namespace AuthBack.src.Domain.Interface
{
    public interface IUserRepository
    {
        Task<bool> VerifyPassword(User user, string password);
        Task<bool> VerifyEmail(User user, string email);
        Task<bool> VerifyCredentials(LoginDTO login);
        Task<User> GetByEmail(string email);
    }
}
