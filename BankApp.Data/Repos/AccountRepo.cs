using BankApp.Data.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly BankAppDataContext _context;

        public AccountRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccount(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(account => account.AccountId == id) ??
                throw new Exception("Account not found.");
        }

        public async Task<Account> GetAccountWithTransactions(int id)
        {
            return await _context.Accounts.Include(a => a.Transactions)
                .FirstOrDefaultAsync(account => account.AccountId == id) ??
               throw new Exception("Account not found.");
        }

        public async Task<Account> CreateAccount(Account newAccount)
        {
            newAccount.AccountTypes = await _context.AccountTypes
                .FirstOrDefaultAsync(at => at.AccountTypeId == newAccount.AccountTypesId);
            await _context.Accounts.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            return newAccount;
        }

        public async Task<Disposition> CreateDisposition(Disposition disposition)
        {
            disposition.Account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == disposition.AccountId) ??
                throw new Exception("Account not found.");

            disposition.Customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == disposition.CustomerId) ??
                throw new Exception("Customer not found.");

            await _context.Dispositions.AddAsync(disposition);
            await _context.SaveChangesAsync();
            return disposition;
        }

        public async Task<List<Account>> GetUserAccounts(int customerId)
        {
            var accountList = await _context.Dispositions
                .Where(d => d.CustomerId == customerId)
                .Select(d => d.Account).ToListAsync();

            return accountList;
        }
    }
}
