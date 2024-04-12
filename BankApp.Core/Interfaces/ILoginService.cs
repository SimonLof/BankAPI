using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ILoginService
    {
        Task Login(UserLoginModel userLogin);
        Task Logout();
    }
}