using BankApp.Data.Identity;
using BankApp.Domain.Entities;

namespace BankApp.Core.Interfaces
{
    public interface ITestService
    {
        Task<List<ApplicationUser>> GetAllUsers();
        Task<Account> GetFirstAccount();
    }
}
