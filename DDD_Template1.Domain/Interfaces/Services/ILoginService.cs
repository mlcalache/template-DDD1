using DDD_Template1.Domain.Entities;

namespace DDD_Template1.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        bool ValidateLogin(User user);
    }
}