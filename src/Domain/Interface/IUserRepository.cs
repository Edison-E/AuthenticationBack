using AuthBack.src.Application.DTO;

namespace AuthBack.src.Domain.Interface
{
    public interface IUserRepository
    {
        Task<bool> VerifyPassword(LoginDTO login);
        Task<bool> VeriffyEmail(LoginDTO login);
        Task<bool> VerifyCredentials(LoginDTO login);
         }
}
