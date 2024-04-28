using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login(UserLoginDTO userLogin);
        Task Logout();
    }
}