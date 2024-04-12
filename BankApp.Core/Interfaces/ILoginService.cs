using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ILoginService
    {
        Task Login(UserLogin userLogin);
        Task Logout();
    }
}