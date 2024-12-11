using AuthBack.src.Domain.Interface;
using AuthBack.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthBack.src.Infrastructure.Repositorios;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AplicationDbContext _context;
    public Repository(AplicationDbContext context) 
    {
      _context = context;
    }
    public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);
}
