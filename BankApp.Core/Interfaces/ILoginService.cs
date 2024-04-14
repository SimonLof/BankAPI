using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login(UserLogin userLogin);
        Task Logout();
    }
}