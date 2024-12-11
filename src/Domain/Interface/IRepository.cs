namespace AuthBack.src.Domain.Interface;

public interface IRepository<T> where T : class
{
    Task<T> GetById(int id);
}
