using BankApp.Data.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repos
{
    public class LoanRepo : ILoanRepo
    {
        private readonly BankAppDataContext _context;

        public LoanRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public async Task<Loan> CreateLoan(Loan loan)
        {
            loan.Account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == loan.AccountId) ??
                throw new Exception("Account not found");

            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
            return loan;
        }
    }
}
