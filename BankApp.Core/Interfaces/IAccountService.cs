using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccount(AccountCreate accountCreateModel);
        Task<List<AccountSimpleView>> GetAccounts(string username);
        Task UserCreateAccount(AccountCreateCustomer accountCreateModel, string username);
    }
}
