namespace AuthBack.src.Infrastructure.Repositorios;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AplicationDbContext context) : base(context)
    {
    }
    public async Task<User> GetByEmail(string email) => _context.Users.FirstOrDefault(x => x.Email == email);

    public async Task<User> GetById(int id) => await base.GetById(id);

}
