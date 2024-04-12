using BankApp.Data.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly BankAppDataContext _context;

        public UserRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public async Task AddNewCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<AccountType> GetSavingsAccount()
        {
            return await _context.AccountTypes.FirstOrDefaultAsync(a => a.AccountTypeId == 2);
        }

        public async Task<AccountType> GetStandardAccount()
        {
            return await _context.AccountTypes.FirstOrDefaultAsync(a => a.AccountTypeId == 1);
        }
    }
}
