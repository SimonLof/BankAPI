using BankApp.Domain.Entities;

namespace BankApp.Data.Interfaces
{
    public interface IUserRepo
    {
        Task AddNewCustomer(Customer customer);
        Task<AccountType> GetStandardAccount();
        Task<AccountType> GetSavingsAccount();
    }
}
