using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Domain.Model;

namespace AuthBack.src.Infrastructure.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;
        public UserRepository(Repository repository)
        { 
         _repository = repository;
        }

        public async Task<bool> VerifyCredentials(LoginDTO login)
        {
            bool passwordIsVerify = await VerifyPassword(login); 
            bool emailIsVerify = await VeriffyEmail(login);

            return emailIsVerify && passwordIsVerify;
        }

        public async Task<bool> VerifyPassword(LoginDTO login)
        {
           User user = await _repository.GetByEmail(login.Email);
           bool passwordIsVerify = user.Password == login.Password;

            return passwordIsVerify;
        }

        public async Task<bool> VeriffyEmail(LoginDTO login)
        {
            User user = await _repository.GetByEmail(login.Email);
            bool emailIsVerify = user.Email == login.Email;

            return emailIsVerify;
        }
    }
}
