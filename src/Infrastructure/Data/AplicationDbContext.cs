namespace AuthBack.src.Infrastructure.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
      : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}
