using BankApp.Domain.DTO;

namespace BankApp.Core.Interfaces
{
    public interface ILoanService
    {
        Task<object> CreateNewLoan(LoanCreateDTO newLoan);
    }
}