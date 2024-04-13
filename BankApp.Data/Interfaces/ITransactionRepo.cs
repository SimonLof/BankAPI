using BankApp.Domain.Entities;

namespace BankApp.Data.Interfaces
{
    public interface ITransactionRepo
    {
        Task<Transaction> CreateTransaction(Transaction transaction);
    }
}