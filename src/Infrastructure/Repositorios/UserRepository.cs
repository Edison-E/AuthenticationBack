using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;
using AuthBack.src.Infrastructure.Data;

namespace AuthBack.src.Infrastructure.Repositorios;

public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    private readonly AplicationDbContext _context;
    public UserRepository(IRepository<User> repository, AplicationDbContext context)
    { 
        _repository = repository;
        _context = context;
    }

    public async Task<bool> VerifyCredentials(LoginDTO login)
    {
        User userByEmail = await GetByEmail(login.Email);
        User userById = await _repository.GetById(userByEmail.Id);

        bool passwordIsVerify = await VerifyPassword(userById, login.Password); 
        bool emailIsVerify = await VerifyEmail(userById,login.Email);

        return emailIsVerify && passwordIsVerify;
    }

    public async Task<bool> VerifyPassword(User user, string password)
    {
       bool passwordIsVerify = BCrypt.Net.BCrypt.Verify(password, user.Password);
       return passwordIsVerify;
    }

    public async Task<bool> VerifyEmail(User user, string email)
    {
        bool emailIsVerify = user.Email == email;
        return emailIsVerify;
    }

    public async Task<User> GetByEmail(string email) => _context.Users.FirstOrDefault(x => x.Email == email);

}
