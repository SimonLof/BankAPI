using BankApp.Data.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repos
{
    public class TestRepo : ITestRepo
    {
        private readonly BankAppDataContext _context;

        public TestRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public async Task<Account> GetFirstAccount()
        {
            return await _context.Accounts.FirstAsync();
        }
    }
}
