namespace AuthBack.src.Domain.Interface;

public interface IRepository<T> where T : class
{
    Task<T> GetByEmail(string email);
}
