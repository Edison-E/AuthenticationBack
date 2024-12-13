using AuthBack.src.Domain.Model;

namespace AuthBack.src.Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
    }
}
