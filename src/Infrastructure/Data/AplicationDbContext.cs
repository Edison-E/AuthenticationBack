using AuthBack.src.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthBack.src.Infrastructure.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
      : base(options)
    {
    }
    public AplicationDbContext() : base(new DbContextOptions<AplicationDbContext>())
    {
    }
    public DbSet<User> Users { get; set; }
}
