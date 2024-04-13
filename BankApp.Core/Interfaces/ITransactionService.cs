using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionView> CustomerSingleTransaction(TransactionCreate transaction, string username);
        Task<TransactionView> SingleTransaction(TransactionCreate transaction);
        Task<TransactionView> TransferTransaction(TransactionBetweenAccountsCreate transaction, string username);
    }
}