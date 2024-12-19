namespace AuthBack.src.Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
    }
}
