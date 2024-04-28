using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccount(AccountCreateDTO accountCreateModel);
        Task<Account> GetAccountFromId(int id);
        Task<List<AccountSimpleViewDTO>> GetAccountsFromName(string username);
        Task<AccountDetailedViewDTO> CustomerGetAccountWithTransactions(int id, string username);
        Task AccountCreateByCustomer(AccountCreateByCustomerDTO accountCreateModel, string username);
    }
}
