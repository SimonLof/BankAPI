using BankApp.Data.Interfaces;
using BankApp.Domain.Entities;

namespace BankApp.Data.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly BankAppDataContext _context;

        public TransactionRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}