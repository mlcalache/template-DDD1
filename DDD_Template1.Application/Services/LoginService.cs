using DDD_Template1.Domain.Entities;
using DDD_Template1.Domain.Interfaces.Services;

namespace DDD_Template1.Application.Services
{
    public class LoginService : ILoginService
    {
        public bool ValidateLogin(User user)
        {
            return user.Username == "admin" && user.Password == "123";
        }
    }
}