using BankApp.Data.Identity;
using BankApp.Domain.Entities;

namespace BankApp.Data.Interfaces
{
    public interface ITestRepo
    {
        Task<List<ApplicationUser>> GetAllUsers();
        Task<Account> GetFirstAccount();
    }
}
