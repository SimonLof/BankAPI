using BankApp.Domain.Entities;

namespace BankApp.Data.Interfaces
{
    public interface ITestRepo
    {
        Task<Account> GetFirstAccount();
    }
}
