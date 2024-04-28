using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionViewDTO> CustomerSingleTransaction(TransactionCreateDTO transaction, string username);
        Task<TransactionViewDTO> SingleTransaction(TransactionCreateDTO transaction);
        Task<TransactionViewDTO> TransferTransaction(TransactionBetweenAccountsCreateDTO transaction, string username);
    }
}