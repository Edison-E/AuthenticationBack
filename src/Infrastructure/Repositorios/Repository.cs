using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using AuthBack.src.Infrastructure.Data;

namespace AuthBack.src.Infrastructure.Repositorios;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AplicationDbContext _context;
    public Repository(AplicationDbContext context) 
    {
      _context = context;
    }

    public async Task<T> GetByEmail(string email) => await _context.FindAsync<T>(email);
}
