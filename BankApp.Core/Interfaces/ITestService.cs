using BankApp.Domain.Entities;

namespace BankApp.Core.Interfaces
{
    public interface ITestService
    {
        Task<Account> GetFirstAccount();
    }
}
