using AuthBack.src.Domain.Interface;
using AuthBack.src.Infrastructure.Data;

namespace AuthBack.src.Infrastructure.Repositorios;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AplicationDbContext _context;
    public Repository(AplicationDbContext context) 
    {
      _context = context;
    }
    public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);
}
