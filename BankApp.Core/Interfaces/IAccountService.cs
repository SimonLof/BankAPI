using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccount(AccountCreate accountCreateModel);
        Task<Account> GetAccountFromId(int id);
        Task<List<AccountSimpleView>> GetAccountsFromName(string username);
        Task<AccountDetailedView> CustomerGetAcountWithTransactions(int id, string username);
        Task UserCreateAccount(AccountCreateCustomer accountCreateModel, string username);
    }
}
