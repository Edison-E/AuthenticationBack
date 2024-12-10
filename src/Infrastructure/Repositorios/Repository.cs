using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthBack.src.Infrastructure.Repositorios
{
    public class Repository : IRepository<User>
    {
        private readonly DbContext _context;
        public Repository(DbContext context) 
        {
          _context = context;
        }

        public async Task<User> GetByEmail(string email) => await _context.FindAsync<User>(email);
        
        
    }
}
