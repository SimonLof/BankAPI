using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Core.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepo _loanRepo;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepo loanRepo, IAccountService accountService, IMapper mapper, ITransactionService transactionService)
        {
            _loanRepo = loanRepo;
            _mapper = mapper;
            _accountService = accountService;
            _transactionService = transactionService;
        }

        public async Task<object> CreateNewLoan(LoanCreateDTO newLoan)
        {
            var loan = _mapper.Map<Loan>(newLoan);

            loan.Date = DateOnly.FromDateTime(DateTime.UtcNow);
            loan.Payments = loan.Amount / loan.Duration;
            loan.Status = "Running";
            loan.Account = await _accountService.GetAccountFromId(loan.AccountId);
            var transactionView = await _transactionService.SingleTransaction(new TransactionCreateDTO
            {
                Amount = newLoan.Amount,
                AccountId = loan.AccountId,
            });

            var createdLoan = await _loanRepo.CreateLoan(loan);
            var loanView = _mapper.Map<LoanViewDTO>(createdLoan);
            return new { Loan = loanView, Transaction = transactionView };
        }

    }
}
// Loan
//public int LoanId { get; set; } x
//public int AccountId { get; set; } x
//public DateOnly Date { get; set; } x
//public decimal Amount { get; set; } x
//public int Duration { get; set; } x
//public decimal Payments { get; set; } x
//public string Status { get; set; } = null!; x
//public virtual Account Account { get; set; } = null!; x

// loan view is just loan without Account.

// Loan Create
//public int AccountId { get; set; }
//public decimal Amount { get; set; }
//public int Duration { get; set; }
//// status is Running or Finished, can have extra comments at the end.
//// duration seem to be years expressed in months (how many times a payment will be made)