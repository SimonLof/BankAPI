using BankApp.Domain.Entities;

namespace BankApp.Data.Interfaces
{
    public interface IAccountRepo
    {
        Task<Account> CreateAccount(Account newAccount);
        Task<Disposition> CreateDisposition(Disposition disposition);
        Task<Account> GetAccount(int id);
        Task<Account> GetAccountWithTransactions(int id);
        Task<List<Account>> GetUserAccounts(int customerId);
    }
}
