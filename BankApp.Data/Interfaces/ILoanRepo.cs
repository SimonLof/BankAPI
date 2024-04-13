using BankApp.Domain.Entities;

namespace BankApp.Data.Interfaces
{
    public interface ILoanRepo
    {
        Task<Loan> CreateLoan(Loan loan);
    }
}
